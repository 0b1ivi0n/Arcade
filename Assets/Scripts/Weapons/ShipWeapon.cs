using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : Weapon
{
    private float _fireTimer;

    private void Update()
    {
        _fireTimer += Time.deltaTime;
        
        if (_fireTimer >= _weaponStrategy.FireRate)
        {
            _weaponStrategy.Fire(_firePoint);
            _fireTimer = 0f;
        }
    }
}
