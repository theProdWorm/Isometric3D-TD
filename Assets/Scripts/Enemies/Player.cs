using UnityEngine;

public class Player : Enemy {
    private Rigidbody rb;

    private void Start ( ) {
        rb = GetComponent<Rigidbody>( );
    }

    protected override void Update ( ) {
        Vector3 move = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rb.position += speed * Time.deltaTime * move;
    }
}