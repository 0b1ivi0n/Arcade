using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem: MonoBehaviour
{
    protected int _health;
    public void SetHealth(int health) => _health = health;

    public bool TakeDamage(int amount)
    {
        Debug.Log(amount);
        _health -= amount;
        Debug.Log(_health);
        if (_health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
