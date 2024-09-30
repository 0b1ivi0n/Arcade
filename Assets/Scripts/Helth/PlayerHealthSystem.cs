using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem {

    public event Action<int> OnHealthChanged;
    private bool _isInvincibility;
    public void AddHealth(int health)
    {
        _health += health;
        OnHealthChanged?.Invoke(_health > 100 ? 100 : _health);
    }
    public override bool TakeDamage(int amount)
    {
        if (!_isInvincibility)
        {
            _health -= amount;
            OnHealthChanged?.Invoke(_health < 0 ? 0 : _health);
            if (_health <= 0)
            {

                Die();
                return true;
            }
        }
        return false;    
    }

    public void SetInvincibility(bool value)
    {
        _isInvincibility = value;
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
