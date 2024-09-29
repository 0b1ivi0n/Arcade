using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem {

    public event Action<int> OnHealthChanged;

    public override bool TakeDamage(int amount)
    {
        _health -= amount;
        OnHealthChanged?.Invoke(_health < 0 ? 0 : _health);
        if (_health <= 0)
        {
            
            Die();
            return true;
        }
        return false;
    }
}
