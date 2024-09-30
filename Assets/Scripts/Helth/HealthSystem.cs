using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HealthSystem: MonoBehaviour
{
    protected int _health;
    protected int _healthInitial;

    public event Action<GameObject> OnDie;

    [SerializeField] protected AudioManager _audioManager;
    //[SerializeField] private TextMeshProUGUI _scoreText;
    //[SerializeField] private float _diedAmount;

    protected void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        //_scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }
    public void SetHealth(int health) 
    {
        _health = health;
        _healthInitial = _health;
    }

    public void ResetHealth() => _health = _healthInitial;
    public virtual bool TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    protected virtual void Die()
    {
        //Destroy(gameObject);
        OnDie?.Invoke(gameObject);
        _audioManager.PlaySFX(_audioManager.Death);
        //UpdateScoreText();
    }

    public static void GameOver()
    {

    }

    //private void UpdateScoreText()
    //{
    //    int scoreValue = int.Parse(_scoreText.text);
    //    _scoreText.text = (scoreValue + _diedAmount).ToString();
    //}

}
