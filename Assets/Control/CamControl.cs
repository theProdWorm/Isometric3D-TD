using UnityEngine;

public class CamControl : MonoBehaviour {
    public float speed;

    private void Update ( ) {
        Vector2 move = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(move.x) == Mathf.Abs(move.y)) move *= Mathf.Cos(Mathf.PI / 4);

        transform.position += move.x * speed * Time.deltaTime * transform.right;
        transform.position += move.y * speed * Time.deltaTime * new Vector3(1, 0, 1);
    }
}