using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _hitPrefab;
    private int _damage;
    private Vector3 _direction;

    private Rigidbody2D _rb;

    public void SetSpeed(float speed) => _speed = speed;
    public void SetDirection(Vector3 direction) => _direction = direction;
    public void SetDamage(int damage) => _damage = damage;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = new Vector2(_speed * _direction.x, _speed * _direction.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (_hitPrefab != null)
        //{
        //    ContactPoint contact = collision.contacts[0];
        //    var hitVFX = Instantiate(_hitPrefab, contact.point, Quaternion.identity);

        //    DestroyParticleSystem(hitVFX);
        //}

        Debug.Log(collision.gameObject.name);
        var healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        Debug.Log(healthSystem);
        if (healthSystem != null)
        {
            bool died = healthSystem.TakeDamage(_damage);

            var spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            Color originalColor = spriteRenderer.color;
            spriteRenderer.DOColor(Color.red, 0.1f).OnComplete(() =>
            {
                spriteRenderer.DOColor(originalColor, 0.1f);
            });
            if (_hitPrefab != null)
            {

                //ContactPoint contact = collision.contacts[0];
                //var hitVFX = Instantiate(_hitPrefab, contact.point, Quaternion.identity);
                if (died)
                {
                    var hitVFX = Instantiate(_hitPrefab, collision.gameObject.transform.position, Quaternion.identity);
                    DestroyParticleSystem(hitVFX);
                }
            }
        }

        Destroy(gameObject);
    }

    void DestroyParticleSystem(GameObject vfx)
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