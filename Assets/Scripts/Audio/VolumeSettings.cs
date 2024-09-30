using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _svxSlider;

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSVXVolume()
    {
        float volume = _svxSlider.value;
        _audioMixer.SetFloat("svx", Mathf.Log10(volume) * 20);
    }


}
