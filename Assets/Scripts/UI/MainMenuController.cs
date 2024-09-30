using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _onPlay;
    [SerializeField] private Button _quit;

    private void Start()
    {
        _onPlay.onClick.AddListener(OnPlayClick);
        _quit.onClick.AddListener( () => Application.Quit());
    }

    public void OnPlayClick()
    {
        LevelManager.Instance.LoadScene("SampleScene");
    }
}
