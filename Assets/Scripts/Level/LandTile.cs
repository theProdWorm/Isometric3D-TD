using UnityEngine;

public class LandTile : MonoBehaviour {
    public float maxGlow;
    public float minGlow;
    public float glowCycle;

    private new MeshRenderer renderer;
    private Color defColor;

    private bool isGlowing;
    private float glowStage;

    private TowerCollection towerCollection;

    private void Awake ( ) {
        towerCollection = FindObjectOfType<TowerCollection>( );
    }

    private void Start ( ) {
        renderer = GetComponent<MeshRenderer>( );

        defColor = renderer.material.color;
    }

    private void Update ( ) {
        if (isGlowing) {
            if (glowStage >= Mathf.PI * 2)
                glowStage -= Mathf.PI * 2;
            glowStage += Time.deltaTime * (1 / glowCycle);

            float lum = minGlow + Mathf.Abs(Mathf.Sin(glowStage)) * (maxGlow - minGlow);

            renderer.material.SetColor("_EmissionColor", Color.yellow * lum);
        }
    }

    private void OnMouseEnter ( ) {
        //renderer.material.color = Color.yellow;

        renderer.material.EnableKeyword("_EMISSION");
        isGlowing = true;
    }

    private void OnMouseExit ( ) {
        //renderer.material.color = defColor;

        renderer.material.DisableKeyword("_EMISSION");
        isGlowing = false;
        glowStage = 0;
    }

    private void OnMouseUpAsButton ( ) {
        // open shop

        if (transform.childCount > 0) return;

        var twr = Instantiate(towerCollection.towers[0], transform);

        renderer.material.color = defColor;
    }
}