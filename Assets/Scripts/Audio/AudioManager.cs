using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _SFXsource;

    public AudioClip Background;
    public AudioClip Death;
    public AudioClip Shoot;
    public AudioClip PickItem;
    public AudioClip ClickButton;

    private void Start()
    {
        _musicSource.clip = Background;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _SFXsource.PlayOneShot(clip);
    }
}
