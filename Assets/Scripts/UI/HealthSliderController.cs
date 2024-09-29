using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderController : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private TextMeshProUGUI _heatlhText;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SubscribeToHealth(PlayerHealthSystem healthSystem)
    {
        
        healthSystem.OnHealthChanged += UpdateHeatlh;
    }

    public void UpdateHeatlh(int health)
    {
        slider.value = health;
        _heatlhText.text = health.ToString();
    }
}
