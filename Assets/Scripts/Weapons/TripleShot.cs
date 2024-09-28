using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TripleShot", menuName = "WeaponStrategy/TripleShot")]
public class TripleShot : WeaponStrategy
{
    [SerializeField] private float _spreadAngle = 15f;

    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < 3; i++)
        {
            var projectile = Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.transform.Rotate(0f, _spreadAngle * (i - 1), 0f);

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(_projectileSpeed);

            Destroy(projectile, _projectileLifetime);
        }
    }
}