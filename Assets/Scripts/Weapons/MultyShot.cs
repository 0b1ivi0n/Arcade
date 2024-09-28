using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Splines;

[CreateAssetMenu(fileName = "MultiShot", menuName = "WeaponStrategy /MultiShot")]
public class MultiShot : WeaponStrategy
{
    [SerializeField] private int _projectileCount = 5; 
    [SerializeField] private float _spreadAngle = 360f;

    private SplineAnimate splineAnimate;

    public override async void Fire(Transform firePoint)
    {
        float angleStep = _spreadAngle / _projectileCount; 
        float angle = 0f;

        splineAnimate = firePoint.GetComponentInParent<SplineAnimate>();
        splineAnimate.enabled = false;
        ResetSpeed();

        for (int i = 0; i < _projectileCount; i++)
        {
  
            float projectileDirX = firePoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float projectileDirY = firePoint.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 projectileVector = new Vector3(projectileDirX, projectileDirY, 0f);
            Vector3 projectileMoveDirection = (projectileVector - firePoint.position).normalized;

            var projectile = Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
            var projectileComponent = projectile.GetComponent<Projectile>();
            //projectile.transform.SetParent(firePoint);    
            
  
            projectileComponent.SetDirection(projectileMoveDirection);
            projectileComponent.SetSpeed(_projectileSpeed);

            //ResetParent(projectile);
   
            Destroy(projectile, _projectileLifetime);
            angle += angleStep;
        }


    }

    async Task ResetSpeed()
    {
        await Task.Delay(400);
        splineAnimate.enabled = true;
    }

    //async Task ResetParent(GameObject projectile)
    //{
    //    await Task.Delay(300);
    //    if (projectile != null) 
    //    {
    //        projectile.transform.SetParent(null);
    //    }
    //}
}

