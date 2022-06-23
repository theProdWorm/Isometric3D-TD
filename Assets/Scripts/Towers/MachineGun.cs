using UnityEngine;

public class MachineGun : Tower, IProjectileShooter {
    public Transform rotArm;
    public Transform rotJoint;

    public Transform r_firePoint;
    public Transform l_firePoint;

    private bool rightBarrel;

    public void AimAtTarget ( ) {
        Vector3 dist = transform.position - Target.transform.position;

        float hAngle = -Mathf.Atan2(dist.z, dist.x) * Mathf.Rad2Deg;
        float vAngle = -Mathf.Atan2(dist.y, Mathf.Sqrt(dist.x * dist.x + dist.z * dist.z)) * Mathf.Rad2Deg;

        var hRot = Quaternion.Euler(rotArm.rotation.x, 0, hAngle + 90);
        var vRot = Quaternion.Euler(vAngle, 0, 0);

        rotArm.localRotation = hRot;
        rotJoint.localRotation = vRot;
    }

    public void Shoot ( ) {
        if (fireCD > 0) return;

        var firePoint = rightBarrel ? r_firePoint : l_firePoint;
        var enemy = Target.GetComponent<Enemy>( );

        enemy.HP -= damage;

        // TODO: muzzle flash at firePoint
        // TODO: play shot sound

        print("Pew!");

        fireCD = 1 / fireRate;
        rightBarrel = !rightBarrel;
    }

    private void Update ( ) {
        if (fireCD > 0)
            fireCD -= Time.deltaTime;

        if (Target == null) return;

        AimAtTarget( );

        Shoot( );
    }
}