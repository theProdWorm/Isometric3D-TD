using UnityEngine;

public class LevelRenderer : MonoBehaviour {
    public static Tile[ ][ ] tiles;

    public Texture2D[ ] levelMaps;

    public GameObject landTile;
    public GameObject roadTile;
    public GameObject rockTile;

    public Transform levelParent;

    public int c_level;

    private void Awake ( ) {
        GenerateLevel(c_level);
    }

    public void GenerateLevel (int level) {
        tiles = new Tile[levelMaps[level].width][ ];

        for (int i = 0; i < tiles.Length; i++) {
            tiles[i] = new Tile[levelMaps[level].height];
        }

        for (int y = 0; y < levelMaps[level].height; y++) {
            for (int x = 0; x < levelMaps[level].width; x++) {
                Color pixel = levelMaps[level].GetPixel(x, y);

                float r = Mathf.Round(pixel.r * 2);
                
                if (r == 2) {
                    tiles[x][y] = Tile.land;

                    Instantiate(landTile, new Vector3(x, 0, -y), Quaternion.identity, levelParent);
                }
                else if (r == 0) {
                    tiles[x][y] = Tile.road;

                    Instantiate(roadTile, new Vector3(x, 0, -y), Quaternion.identity, levelParent);
                }
                else {
                    tiles[x][y] = Tile.rock;

                    Instantiate(rockTile, new Vector3(x, 0, -y), Quaternion.identity, levelParent);
                }
            }
        }
    }
}