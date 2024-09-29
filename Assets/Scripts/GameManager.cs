using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealthSystem _playerHealthSystem;
    [SerializeField] private HealthSliderController _playerSliderController;

    private void Start()
    {
        _playerHealthSystem.SetHealth(100);
        _playerSliderController.SubscribeToHealth(_playerHealthSystem);
    }
}
