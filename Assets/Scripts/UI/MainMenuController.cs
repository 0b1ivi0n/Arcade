using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _onPlay;
    [SerializeField] private Button _quit;
    [SerializeField] private TextMeshProUGUI _BestScoreText;

    private void Start()
    {
        Time.timeScale = 1f;
        string score = "0";
        if (PlayerPrefs.HasKey("bestScore"))
        {
            score = PlayerPrefs.GetString("bestScore");
        }
        _BestScoreText.text = score;
        _onPlay.onClick.AddListener(OnPlayClick);
        _quit.onClick.AddListener( () => Application.Quit());
    }

    public void OnPlayClick()
    {
        LevelManager.Instance.LoadScene("SampleScene");
    }
}
