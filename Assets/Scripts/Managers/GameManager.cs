using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealthSystem _playerHealthSystem;
    [SerializeField] private HealthSliderController _playerSliderController;

    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _menu;
    private void Start()
    {
        _playerHealthSystem.SetHealth(100);
        _playerSliderController.SubscribeToHealth(_playerHealthSystem);

        _pause.onClick.AddListener(OnPause);
        _resume.onClick.AddListener(UnPaused);
        _menu.onClick.AddListener(OnMenuClick);
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
}
