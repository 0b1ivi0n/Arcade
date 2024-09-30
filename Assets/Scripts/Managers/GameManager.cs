using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealthSystem _playerHealthSystem;
    [SerializeField] private HealthSliderController _playerSliderController;

    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _menu;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float updateInterval = 1f;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _gameOverScoreText;
    [SerializeField] private TextMeshProUGUI _BestScoreText;

    [SerializeField] private Button _restart;
    private void Start()
    {
        Time.timeScale = 1f;
        _playerHealthSystem.SetHealth(100);
        _playerSliderController.SubscribeToHealth(_playerHealthSystem);

        _pause.onClick.AddListener(OnPause);
        _resume.onClick.AddListener(UnPaused);
        _menu.onClick.AddListener(OnMenuClick);
        _restart.onClick.AddListener(Restart);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateInterval)
        {
            _score += 10;
            UpdateScoreText();
            timer = 0f;
        }
    }

    private void Restart() {
        LevelManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
    }

    public void UnPaused()
    {
        Time.timeScale = 1f;
    }

    public void OnMenuClick()
    {
        LevelManager.Instance.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        _gameOverScoreText.text = _scoreText.text;
        PlayerPrefs.SetString("scoreText", _scoreText.text);
        int bestScore = 0;
        if (PlayerPrefs.HasKey("bestScore")) {
            bestScore = int.Parse(PlayerPrefs.GetString("bestScore"));
        }
        int scoreValue = int.Parse(_scoreText.text);
        if (scoreValue > bestScore)
        {
            bestScore = scoreValue;
            PlayerPrefs.SetString("bestScore", _scoreText.text);
        }

        _BestScoreText.text = bestScore.ToString();

    }
}
