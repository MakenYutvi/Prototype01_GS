using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scene
{
    //Паттерн Заместитель. Оборачивает базовый класс 
    public sealed class ApplicationSceneManager : MonoBehaviour, ISceneManager
    {
        private UnitySceneManager sceneManager;

        [FormerlySerializedAs("ProgressBarSlider")]
        [SerializeField]
        private Slider progressBarSlider;

        [FormerlySerializedAs("VisualPart")]
        [SerializeField]
        private GameObject visualPart;

        [FormerlySerializedAs("FakeLoadTime")]
        [SerializeField]
        private float fakeLoadTime = 1f;

        private Coroutine loadingCoroutine;
        
        public void LoadSceneAsync(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
            {
                throw new Exception("Scene name is empty!");
            }

            if (this.loadingCoroutine != null)
            {
                return;
            }

            this.loadingCoroutine = this.StartCoroutine(this.LoadSceneRoutine(sceneName));
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            this.visualPart.SetActive(true);
            yield return this.FakeLoading();
            
            this.sceneManager.LoadSceneAsync(sceneName);
            while (this.sceneManager.IsLoading())
            {
                yield return null;
            }
            
            this.visualPart.SetActive(false);
        }

        private IEnumerator FakeLoading()
        {
            float timer = 0;
            while (timer < this.fakeLoadTime)
            {
                timer += Time.deltaTime;
                var progress = timer / this.fakeLoadTime;
                this.progressBarSlider.value = progress;
                yield return null;
            }
        }

        private void Awake()
        {
            this.sceneManager = new UnitySceneManager(this);
            this.visualPart.SetActive(false);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}