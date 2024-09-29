using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

[CreateAssetMenu(fileName = "TripleShot", menuName = "WeaponStrategy/TripleShot")]
public class TripleShot : WeaponStrategy
{

    [SerializeField] private float _offset = 0.5f;
    public override void Fire(Transform firePoint)
    {
        FireProjectile(firePoint.position);
        FireProjectile(firePoint.position + new Vector3(-_offset, 0, 0));
        FireProjectile(firePoint.position + new Vector3(_offset, 0, 0));
    }
    private void FireProjectile(Vector3 position)
    {
        var projectile = Instantiate(_projectilePrefab, position, Quaternion.identity);
        var projectileComponent = projectile.GetComponent<Projectile>();

        projectileComponent.SetSpeed(_projectileSpeed);
        projectileComponent.SetDirection(Vector2.down);  
        projectileComponent.SetDamage(_damage);

        Destroy(projectile, _projectileLifetime);
    }

}