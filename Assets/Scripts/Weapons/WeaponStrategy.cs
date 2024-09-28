using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponStrategy : ScriptableObject
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _projectileSpeed;
    [SerializeField] protected float _projectileLifetime;
    [SerializeField] protected GameObject _projectilePrefab;
    public int Damage => _damage;
    public float FireRate => _fireRate;

    public virtual void Initialize()
    {

    }

    public abstract void Fire(Transform firePoint);

}
