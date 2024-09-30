using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _onPlay;

    private void Start()
    {
        _onPlay.onClick.AddListener(OnPlayClick);
    }

    public void OnPlayClick()
    {
        LevelManager.Instance.LoadScene("SampleScene");
    }
}
