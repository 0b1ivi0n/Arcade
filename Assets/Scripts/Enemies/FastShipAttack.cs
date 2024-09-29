using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FastShipAttack : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private int _damage;

    [SerializeField] private Transform _player; 
    [SerializeField] private float _explosionDistance = 2f;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.transform;
    }
    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer < _explosionDistance)
        {
            DoExplosion();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            var healthSystem = collision.gameObject.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(_damage);
            }
            DoExplosion();
        }
    }

    private void DoExplosion()
    {

        var hitVFX = Instantiate(_explosionEffect, gameObject.transform.position, Quaternion.identity);
        DestroyParticleSystem(hitVFX);
        Destroy(gameObject);
    }

    private void DestroyParticleSystem(GameObject vfx)
    {
        //// do something
        var ps = vfx.GetComponent<ParticleSystem>();
        if (ps == null)
        {
            ps = vfx.GetComponentInChildren<ParticleSystem>();
        }
        Destroy(vfx, ps.main.duration);
    }
}
