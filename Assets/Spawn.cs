using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject goblin;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(goblin);
        }
    }
}
