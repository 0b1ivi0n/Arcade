using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField] private int _healthAmount = 50;
    protected override void ApplyPowerUp()
    {
        var healthSystem = _player.GetComponent<PlayerHealthSystem>();
        healthSystem.AddHealth(_healthAmount);

        DestroyPowerUp();
    }
}
