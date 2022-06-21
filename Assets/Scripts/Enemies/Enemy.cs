using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public float speed;
    public float hp;
    public float damage;

    protected Transform c_tile;
    protected Transform n_tile;

    private void Start ( ) {
        
    }

    protected virtual void Update ( ) {

    }
}