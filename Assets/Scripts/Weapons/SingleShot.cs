using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleShot", menuName = "WeaponStrategy /SingleShot")]
public class SingleShot : WeaponStrategy
{
    public override void Fire(Transform firePoint)
    {
        var projectile = Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);

        var projectileComponent = projectile.GetComponent<Projectile>();
        projectileComponent.SetSpeed(_projectileSpeed);
        projectileComponent.SetDirection(new Vector3(0, -1, 0));
        projectileComponent.SetDamage(_damage);

        Destroy(projectile, _projectileLifetime);
    }
}
