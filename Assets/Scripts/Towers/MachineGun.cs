using UnityEngine;
using System.Linq;

public class MachineGun : MonoBehaviour, IProjectileShooter {
    public Transform rotArm;
    public Transform rotJoint;

    public void AimAt (Transform target) {
        Vector3 dist = transform.position - target.position;

        float hAngle = -Mathf.Atan2(dist.z, dist.x) * Mathf.Rad2Deg;
        float vAngle = -Mathf.Atan2(dist.y, Mathf.Sqrt(dist.x * dist.x + dist.z * dist.z)) * Mathf.Rad2Deg;

        var hRot = Quaternion.Euler(rotArm.rotation.x, 0, hAngle + 90);
        var vRot = Quaternion.Euler(vAngle, 0, 0);

        rotArm.localRotation = hRot;
        rotJoint.localRotation = vRot;
    }

    private void Update ( ) {
        var enemies = FindObjectsOfType<Enemy>( );

        if (enemies.Length <= 0) return;

        var closestEnemy = enemies.Aggregate((closest, next) =>
        Vector3.Distance(transform.position, next.transform.position) < Vector3.Distance(transform.position, closest.transform.position) ? next : closest);

        AimAt(closestEnemy.transform);
    }
}