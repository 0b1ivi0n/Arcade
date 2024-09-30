using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem: MonoBehaviour
{
    protected int _health;
    protected int _healthInitial;

    public event Action<GameObject> OnDie;

    public void SetHealth(int health) 
    {
        _health = health;
        _healthInitial = _health;
    }

    public void ResetHealth() => _health = _healthInitial;
    public virtual bool TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    protected virtual void Die()
    {
        //Destroy(gameObject);
        OnDie?.Invoke(gameObject);
    }

}
