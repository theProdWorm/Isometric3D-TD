using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public float speed;
    public float hp;
    public float damage;
    public float HP {
        get => hp;
        set {
            hp = value;
            if (hp <= 0) Die( );
        }
    }

    [HideInInspector]
    public float travelledDistance;

    private readonly List<Vector3> path = new( );

    protected virtual void Awake ( ) {
        HP = hp;

        List<Vector2> roadTiles = new( );

        for (int x = 0; x < LevelRenderer.tiles.Length; x++) {
            for (int y = 0; y < LevelRenderer.tiles[x].Length; y++) {
                Tile tile = LevelRenderer.tiles[x][y];

                if (tile == Tile.road)
                    roadTiles.Add(new Vector2(x, y));
            }
        }

        path.Add(new Vector3(roadTiles[0].x, 1, -roadTiles[0].y));
        roadTiles.RemoveAt(0);

        int len = roadTiles.Count;
        int i = 0;
        while (roadTiles.Count > 0) {
            if (i > len) break; // prevents infinite loop

            var prev = new Vector3(path[^1].x, -path[^1].z);

            var next = AdjacentTile(prev, roadTiles);

            path.Add(new Vector3(next.x, 1, -next.y));
            roadTiles.Remove(next);

            i++;
        }

        transform.position = path[0];
    }

    private Vector3 AdjacentTile (Vector2 prev, List<Vector2> roadTiles) {
        for (int i = 0; i < roadTiles.Count; i++) {
            var next = roadTiles[i];

            float distX = Mathf.Abs(prev.x - next.x);
            float distY = Mathf.Abs(prev.y - next.y);

            if (distX == 1 ^ distY == 1 && distX == 0 ^ distY == 0)
                return next;
        }

        throw new System.NullReferenceException("Path is not walkable.");
    }

    protected virtual void Update ( ) {
        if (path.Count <= 0) {
            // TODO: deal damage to "player"

            Destroy(gameObject);
            return;
        }

        var newPos = Vector3.MoveTowards(transform.position, path[0], speed * Time.deltaTime);
        var moveDelta = (newPos - transform.position).magnitude;

        transform.position = newPos;
        travelledDistance += moveDelta;

        if (transform.position == path[0])
            path.RemoveAt(0);
    }

    protected virtual void Die ( ) {
        Destroy(gameObject);

        print($"{name} was killed!");
    }
}