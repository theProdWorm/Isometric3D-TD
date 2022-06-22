using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Tower : MonoBehaviour {
    public int price;

    public float damage;
    public float fireRate;
    public float range;

    public TargetMode targetMode;

    protected float fireCD;

    protected Transform Target { get {
            var enemies = (from enemy in FindObjectsOfType<Enemy>( )
                           where Vector3.Distance(transform.position, enemy.transform.position) <= range
                           select enemy).ToArray( );

            if (enemies.Length <= 0)
                return null;

            return SelectTarget(enemies);
        }
    }

    protected Func<Enemy[ ], Transform> SelectTarget {
        get {
            return targetMode switch {
                TargetMode.first => First,
                TargetMode.last => Last,
                TargetMode.strong => Strong,
                TargetMode.weak => Weak,
                TargetMode.close => Close,
                TargetMode.far => Far,
                _ => First
            };
        }
    }

    private Transform First (Enemy[ ] enemies) {
        var first = enemies[0];

        foreach (var enemy in enemies) {
            if (enemy.travelledDistance > first.travelledDistance)
                first = enemy;
        }

        return first.transform;
    }

    private Transform Last (Enemy[ ] enemies) {
        var last = enemies[0];

        foreach (var enemy in enemies) {
            if (enemy.travelledDistance < last.travelledDistance)
                last = enemy;
        }

        return last.transform;
    }

    private Transform Strong (Enemy[ ] enemies) {
        var strongest = enemies[0];
        List<Enemy> _enemies = enemies.OrderByDescending(x => x.travelledDistance).ToList( );

        foreach (var enemy in _enemies) {
            if (enemy.hp > strongest.hp)
                strongest = enemy;
        }

        return strongest.transform;
    }

    private Transform Weak (Enemy[ ] enemies) {
        var weakest = enemies[0];
        List<Enemy> _enemies = enemies.OrderByDescending(x => x.travelledDistance).Reverse( ).ToList( );

        foreach (var enemy in _enemies) {
            if (enemy.hp < weakest.hp)
                weakest = enemy;
        }

        return weakest.transform;
    }

    private Transform Close (Enemy[ ] enemies) {
        var closest = enemies[0];

        foreach (var enemy in enemies) {
            var enemyDist = Vector3.Distance(enemy.transform.position, transform.position);
            var closestDist = Vector3.Distance(closest.transform.position, transform.position);

            if (enemyDist < closestDist)
                closest = enemy;
        }

        return closest.transform;
    }

    private Transform Far (Enemy[ ] enemies) {
        var furthest = enemies[0];

        foreach (var enemy in enemies) {
            var enemyDist = Vector3.Distance(enemy.transform.position, transform.position);
            var closestDist = Vector3.Distance(furthest.transform.position, transform.position);

            if (enemyDist > closestDist)
                furthest = enemy;
        }

        return furthest.transform;
    }
}