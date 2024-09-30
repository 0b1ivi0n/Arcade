using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private float _lifetime = 20f;
    [SerializeField] private Transform _targetPosition;

    [SerializeField] private float _moveDistance = 0.5f;  
    [SerializeField] private float _moveDuration = 1f;  
    [SerializeField] private float _scaleDuration = 0.5f; 
    [SerializeField] private float _scaleFactor = 1.2f;
    protected GameObject _player;
    protected AudioManager _audioManager;

    protected virtual void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
        StartFloatingAnimation();
    }

    private void Update()
    {
        //transform.position += new Vector3(0, -_speedScrolling * Time.deltaTime, 0);
    }
    private void StartFloatingAnimation()
    {
        //transform.DOMoveY(transform.position.y + _moveDistance, _moveDuration)
        //    .SetLoops(-1, LoopType.Yoyo)
        //    .SetEase(Ease.InOutSine);
        //Vector3 targetPosition = new Vector3(transform.position.x, _targetPosition.position.y, transform.position.z);
        Vector3 targetPosition = new Vector3(transform.position.x, -5, transform.position.z);
        transform.DOMove(targetPosition, _lifetime)
           .SetEase(Ease.Linear);

        transform.DOScale(Vector3.one * _scaleFactor, _scaleDuration)
            .SetLoops(-1, LoopType.Yoyo) 
            .SetEase(Ease.InOutSine);   
    }

    protected abstract void ApplyPowerUp();
    protected void DestroyPowerUp()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _audioManager.PlaySFX(_audioManager.PickItem);
            ApplyPowerUp();
        }
    }

    protected void TurnOffVisual()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    protected void TurnOnVisual()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}