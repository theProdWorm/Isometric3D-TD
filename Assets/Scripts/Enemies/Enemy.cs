using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public float speed;
    public float hp;
    public float damage;

    private List<Vector3> path = new List<Vector3>( );

    protected virtual void Start ( ) {
        List<Vector2> roadTiles = new List<Vector2>( );

        for (int x = 0; x < LevelRenderer.tiles.Length; x++) {
            for (int y = 0; y < LevelRenderer.tiles[x].Length; y++) {
                Tile tile = LevelRenderer.tiles[x][y];

                if (tile == Tile.road)
                    roadTiles.Add(new Vector2(x, y));
            }
        }

        path.Add(new Vector3(roadTiles[0].x, 1, -roadTiles[0].y));
        roadTiles.RemoveAt(0);

        while (roadTiles.Count > 0) {
            var prev = new Vector3(path[^1].x, -path[^1].z);

            var next = AdjacentTile(prev, roadTiles);

            path.Add(new Vector3(next.x, 1, -next.y));
            roadTiles.Remove(next);
        }

        for (int i = 0; i < path.Count; i++) {
            print($"{i + 1}: {path[i]}");
        }

        transform.position = path[0] + Vector3.up;
    }

    private Vector3 AdjacentTile (Vector2 prev, List<Vector2> roadTiles) {
        for (int i = 0; i < roadTiles.Count; i++) {
            var next = roadTiles[i];

            float distX = Mathf.Abs(prev.x - next.x);
            float distY = Mathf.Abs(prev.y - next.y);

            if (distX == 1 ^ distY == 1 && distX == 0 ^ distY == 0)
                return next;
        }

        throw new System.NullReferenceException( );
    }

    protected virtual void Update ( ) {
        if (path.Count <= 0) return;

        transform.position = Vector3.MoveTowards(transform.position, path[0], speed * Time.deltaTime);

        if (transform.position == path[0])
            path.RemoveAt(0);
    }
}