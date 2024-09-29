using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAttack : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
