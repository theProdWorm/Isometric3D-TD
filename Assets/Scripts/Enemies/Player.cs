using UnityEngine;

public class Player : Enemy {
    private Rigidbody rb;

    private void Start ( ) {
        rb = GetComponent<Rigidbody>( );
    }

    private void Update ( ) {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rb.position += move * Time.deltaTime * speed;
    }
}