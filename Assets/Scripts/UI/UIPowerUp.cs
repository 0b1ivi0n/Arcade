using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPowerUp : MonoBehaviour
{
    private Image _img;
    [SerializeField] private float _flashingTime = 5f;
    void Start()
    {
        _img = GetComponent<Image>();
    }

    public IEnumerator PowerUpImageLifetimeController(float duration)
    {
        _img.enabled = true;
        yield return new WaitForSeconds(duration - _flashingTime);
        _img.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo);
        yield return new WaitForSeconds(_flashingTime);
        _img.enabled = false;
    }
}
