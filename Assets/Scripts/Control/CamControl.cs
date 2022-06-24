using UnityEngine;

public class CamControl : MonoBehaviour {
    public float panSpeed;
    public float zoomSpeed;
    public float zoomLerp;

    public float minZoom, maxZoom;
    public float minPanX, maxPanX, minPanY, maxPanY;

    private float zoomTarget;

    private bool backView;

    private Camera cam;

    private Vector3 Back => new(-LevelRenderer.tiles.Length, 0, 0);
    private Vector3 Front =>  new(0, 0, LevelRenderer.tiles.Length);

    private void Start ( ) {
        cam = GetComponent<Camera>( );

        zoomTarget = cam.orthographicSize;

        transform.position -= transform.forward * 100;
        transform.position += transform.right * LevelRenderer.tiles.Length / 2;
    }

    private void Update ( ) {
        PanKB( );
        Zoom( );

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            ChangeView( );
    }

    private void PanKB ( ) {
        Vector2 move = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(move.x) == Mathf.Abs(move.y)) move *= Mathf.Cos(Mathf.PI / 4);

        transform.position += move.x * panSpeed * Time.deltaTime * transform.right;
        transform.position += move.y * (backView ? -panSpeed : panSpeed) * Time.deltaTime * new Vector3(1, 0, 1);
    }

    private void Zoom ( ) {
        zoomTarget = Mathf.Clamp(zoomTarget + zoomSpeed * Time.deltaTime * -Input.mouseScrollDelta.y, minZoom, maxZoom);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomTarget, zoomLerp);
    }

    private void ChangeView ( ) {
        backView = !backView;

        transform.position += transform.forward * 100;

        transform.rotation = Quaternion.Euler(30, backView ? 225 : 45, 0);
        transform.position -= transform.forward * 100;
    }
}