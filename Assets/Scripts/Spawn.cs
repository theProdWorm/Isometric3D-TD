using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject goblin;
    public GameObject orc;

    private void Update ( ) {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Instantiate(goblin);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Instantiate(orc);
        }
    }
}