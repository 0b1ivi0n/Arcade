using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponStrategy _weaponStrategy;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected LayerMask _layer;

    protected void Start()
    {
        _weaponStrategy.Initialize();
    }

    public void SetWeaponStratedy(WeaponStrategy weaponStrategy)
    {
        _weaponStrategy = weaponStrategy;
        _weaponStrategy.Initialize();
    }
}
