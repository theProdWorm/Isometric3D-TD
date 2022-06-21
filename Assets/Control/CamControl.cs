using UnityEngine;

public class CamControl : MonoBehaviour {
    public float panSpeed;
    public float zoomSpeed;
    public float zoomLerp;

    public float minZoom, maxZoom;
    public float minPanX, maxPanX, minPanY, maxPanY;

    private float zoomTarget;

    private Camera cam;

    private void Start ( ) {
        cam = GetComponent<Camera>( );

        zoomTarget = cam.orthographicSize;

        transform.position -= transform.forward * 100;
    }

    private void Update ( ) {
        PanKB( );
        Zoom( );
    }

    private void PanKB ( ) {
        Vector2 move = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(move.x) == Mathf.Abs(move.y)) move *= Mathf.Cos(Mathf.PI / 4);

        transform.position += move.x * panSpeed * Time.deltaTime * transform.right;
        transform.position += move.y * panSpeed * Time.deltaTime * new Vector3(1, 0, 1);
    }

    private void Zoom ( ) {
        zoomTarget = Mathf.Clamp(zoomTarget + zoomSpeed * Time.deltaTime * -Input.mouseScrollDelta.y, minZoom, maxZoom);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomTarget, zoomLerp);
    }
}