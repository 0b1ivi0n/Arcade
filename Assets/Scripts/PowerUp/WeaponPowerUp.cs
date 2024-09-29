using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : PowerUp
{
    [SerializeField] private float _duration = 15f;
    [SerializeField] protected WeaponStrategy _weaponStrategy;
    [SerializeField] UIPowerUp uIPowerUp;

    private Weapon weapon;

    protected override void Start()
    {
        base.Start();
        uIPowerUp = GameObject.FindGameObjectWithTag("ImageWeaponPWUP").GetComponent<UIPowerUp>();
    }
    protected override void ApplyPowerUp()
    {
        StartCoroutine(uIPowerUp.PowerUpImageLifetimeController(_duration));
        weapon = _player.GetComponent<ShipWeapon>();
        var currentWeaponStrategy = weapon.GetWeaponStrategy();
        weapon.SetWeaponStratedy(_weaponStrategy);
        StartCoroutine(ResetWeaponStrategy(currentWeaponStrategy));
    }

    

    IEnumerator  ResetWeaponStrategy(WeaponStrategy weaponStrategy)
    {
        TurnOffVisual();
        yield return new WaitForSeconds(_duration);
        weapon.SetWeaponStratedy(weaponStrategy);
        DestroyPowerUp();
    }
}
