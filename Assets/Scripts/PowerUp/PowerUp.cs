using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private float _moveDistance = 0.5f;  
    [SerializeField] private float _moveDuration = 1f;  
    [SerializeField] private float _scaleDuration = 0.5f; 
    [SerializeField] private float _scaleFactor = 1.2f;

    protected GameObject _player;
    protected virtual void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        StartFloatingAnimation();
    }

    private void StartFloatingAnimation()
    {
        transform.DOMoveY(transform.position.y + _moveDistance, _moveDuration)
            .SetLoops(-1, LoopType.Yoyo)  
            .SetEase(Ease.InOutSine);     

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
            ApplyPowerUp();
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