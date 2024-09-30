using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Slider _progressBar;

    private float _target;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

        _loaderCanvas.SetActive(true);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _progressBar.value = progressValue;
            yield return null;
        }

        _loaderCanvas.SetActive(false);
    }

    //public async void LoadScene(string sceneName)
    //{
    //    _target = 0;
    //    _progressBar.value = 0;

    //    var scene = SceneManager.LoadSceneAsync(sceneName);
    //    scene.allowSceneActivation = false;

    //    _loaderCanvas.SetActive(true);

    //    // ������ �� ���������� ��������
    //    while (scene.progress < 0.9f)
    //    {
    //        _target = Mathf.Clamp01(scene.progress / 0.9f); // �������� ����� �� 0 �� 1
    //        await Task.Delay(100);
    //    }

    //    // ������������� ��������� �������� �� 100%
    //    _target = 1f;

    //    // ������ ��������, ����� �������� 100% �������� ����� ����������
    //    await Task.Delay(1000);

    //    // ���������� �����
    //    scene.allowSceneActivation = true;
    //    _loaderCanvas.SetActive(false);
    //}


    //public async void LoadScene(string sceneName)
    //{
    //    _target = 0;
    //    _progressBar.value = 0;

    //    var scene = SceneManager.LoadSceneAsync(sceneName);
    //    scene.allowSceneActivation = false;

    //    _loaderCanvas.SetActive(true);

    //    // ������ �� ���������� ��������
    //    while (scene.progress < 0.9f)
    //    {
    //        _target = Mathf.Clamp01(scene.progress / 0.9f); // �������� ����� �� 0 �� 1
    //        await Task.Delay(100);
    //    }

    //    // ������������� ��������� �������� �� 100%
    //    _target = 1f;

    //    // ������ ��������, ����� �������� 100% �������� ����� ����������
    //    await Task.Delay(1000);

    //    // ���������� �����
    //    scene.allowSceneActivation = true;
    //    _loaderCanvas.SetActive(false);
    //}
    //public async void LoadScene(string sceneName)
    //{
    //    _target = 0;
    //    _progressBar.value = 0;

    //    var scene = SceneManager.LoadSceneAsync(sceneName);
    //    scene.allowSceneActivation = false;

    //    _loaderCanvas.SetActive(true);

    //    // ������ �� ���������� ��������
    //    while (scene.progress < 0.9f)
    //    {
    //        _target = Mathf.Clamp01(scene.progress / 0.9f); // �������� ����� �� 0 �� 1
    //        await Task.Delay(100);
    //    }

    //    // ������������� ��������� �������� �� 100%
    //    _target = 1f;

    //    // ������ ��������, ����� �������� 100% �������� ����� ����������
    //    await Task.Delay(1000);

    //    // ���������� �����
    //    scene.allowSceneActivation = true;
    //    _loaderCanvas.SetActive(false);
    //}

    //private void Update()
    //{
    //    // ������ ��������� �������� ��������
    //    _progressBar.value = Mathf.MoveTowards(_progressBar.value, _target, 3 * Time.deltaTime);
    //}
}