using UnityEngine;

public class LandTile : MonoBehaviour {
    public float maxScale;

    private TowerCollection towerCollection;

    void Awake ( ) {
        towerCollection = FindObjectOfType<TowerCollection>( );
    }

    void Update ( ) {

    }

    private void OnMouseEnter ( ) {
        transform.localScale = new Vector3(1, maxScale, 1);
        transform.position += Vector3.up * ((maxScale - 1) / 2);
    }

    private void OnMouseExit ( ) {
        transform.localScale = Vector3.one;
        transform.position -= Vector3.up * ((maxScale - 1) / 2);
    }

    private void OnMouseUpAsButton ( ) {
        // open shop

        var twr = Instantiate(towerCollection.towers[0]);
        twr.transform.position += transform.position;
    }
}