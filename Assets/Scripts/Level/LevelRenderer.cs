using UnityEngine;

public class LevelRenderer : MonoBehaviour {
    public Texture2D[ ] levelMaps;

    public GameObject landTile;
    public GameObject roadTile;

    public Transform levelParent;

    public int c_level;

    void Start ( ) {
        GenerateLevel(c_level);
    }

    public void GenerateLevel (int level) {
        for (int x = 0; x < levelMaps[level].width; x++) {
            for (int y = 0; y < levelMaps[level].height; y++) {
                Color pixel = levelMaps[level].GetPixel(x, y);
                float r = Mathf.Round(pixel.r);

                if (r == 1) {
                    // white pixel - placeable tile

                    Instantiate(landTile, new Vector3(x, 0, -y), Quaternion.identity, levelParent);
                }
                else {
                    // black pixel - road

                    Instantiate(roadTile, new Vector3(x, 0, -y), Quaternion.identity, levelParent);
                }
            }
        }
    }
}