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
        renderer.material.color = Color.yellow;
    }

    private void OnMouseExit ( ) {
        renderer.material.color = defColor;
    }

    private void OnMouseUpAsButton ( ) {
        // open shop

        if (transform.childCount > 0) return;

        var twr = Instantiate(towerCollection.towers[0], transform);
    }
}