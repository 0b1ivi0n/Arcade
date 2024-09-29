using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [SerializeField] private float _duration = 15f;
    [SerializeField] UIPowerUp uIPowerUp;
    protected override void Start()
    {
        base.Start();
        uIPowerUp = GameObject.FindGameObjectWithTag("ImageShieldPWUP").GetComponent<UIPowerUp>();
    }

    protected override void ApplyPowerUp()
    {
        StartCoroutine(uIPowerUp.PowerUpImageLifetimeController(_duration));
        TurnOffVisual();
        StartCoroutine(InvincibilityRoutine(_duration));
    }

    private IEnumerator InvincibilityRoutine(float duration)
    {
        SpriteRenderer spriteRenderer = _player.GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0.5f, 0.2f).SetLoops(-1, LoopType.Yoyo);
        //Physics2D.IgnoreLayerCollision(6, 11, true);
        _player.GetComponent<PlayerHealthSystem>().SetInvincibility(true);
        yield return new WaitForSeconds(duration);
        _player.GetComponent<PlayerHealthSystem>().SetInvincibility(false);
        spriteRenderer.DOKill();
        spriteRenderer.color = new Color(1, 1, 1, 1);
        //Physics2D.IgnoreLayerCollision(6, 11, false);
    }
}
