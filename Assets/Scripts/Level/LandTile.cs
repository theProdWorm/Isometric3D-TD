using UnityEngine;

public class LandTile : MonoBehaviour {
    public float maxScale;

    private new MeshRenderer renderer;
    private Color defColor;

    private TowerCollection towerCollection;

    private void Awake ( ) {
        towerCollection = FindObjectOfType<TowerCollection>( );
    }

    private void Start ( ) {
        renderer = GetComponent<MeshRenderer>( );

        defColor = renderer.material.color;
    }

    private void OnMouseEnter ( ) {
        //transform.localScale = new Vector3(1, maxScale, 1);
        //transform.position += Vector3.up * ((maxScale - 1) / 2);

        renderer.material.color = Color.yellow;
    }

    private void OnMouseExit ( ) {
        //transform.localScale = Vector3.one;
        //transform.position -= Vector3.up * ((maxScale - 1) / 2);

        renderer.material.color = defColor;
    }

    private void OnMouseUpAsButton ( ) {
        // open shop

        var twr = Instantiate(towerCollection.towers[0]);
        twr.transform.position += new Vector3(transform.position.x, 0, transform.position.z);
    }
}