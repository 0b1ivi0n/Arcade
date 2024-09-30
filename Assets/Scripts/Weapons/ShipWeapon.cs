using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ShipWeapon : Weapon
{
    protected AudioManager _audioManager;

    protected override void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private float _fireTimer;

    private void Update()
    {
        _fireTimer += Time.deltaTime;
        
        if (_fireTimer >= _weaponStrategy.FireRate)
        {
            if (gameObject.CompareTag("Player"))
            {
                _audioManager.PlaySFX(_audioManager.Shoot);
            }
            _weaponStrategy.Fire(_firePoint);
            _fireTimer = 0f;
        }
    }
}
