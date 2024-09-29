using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem: MonoBehaviour
{
    protected int _health;
    public void SetHealth(int health) => _health = health;

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
        Destroy(gameObject);
    }

}
