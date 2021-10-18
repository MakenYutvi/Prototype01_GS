using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _SceneManager : MonoBehaviour, _ISceneManager
{
    public Slider ProgressBarSlider;
    public GameObject VisualPart;
    public float FakeLoadTime = 1f;

    private void Awake()
    {
     
        DontDestroyOnLoad(gameObject);
        VisualPart.SetActive(false);
    }
  
    public void _LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadGameSceneCor(sceneName));
    }

    private IEnumerator LoadGameSceneCor(string sceneName)
    {
        VisualPart.SetActive(true);
        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneName);
        asyncLoading.allowSceneActivation = false;

        float timer = 0;

        while (timer < FakeLoadTime || asyncLoading.progress < 0.9f)
        {
            timer += Time.deltaTime;
            SetProgressBarProgress(timer / FakeLoadTime);

            yield return null;
        }

        asyncLoading.allowSceneActivation = true;

        while (!asyncLoading.isDone)
            yield return null;
        VisualPart.SetActive(false);
    }

    private void SetProgressBarProgress(float progress)
    {
        ProgressBarSlider.value = progress;
    }
}
