using System.Collections;
using UnityEngine;


    public interface ISceneManager
    {
        void LoadSceneAsync(string sceneName);
    }
    
    public sealed class UnitySceneManager : ISceneManager
    {
        private readonly MonoBehaviour coroutineDispatcher;

        private bool allowSceneActivation;

        private Coroutine loadingCoroutine;

        private AsyncOperation loadingOperation;
        
        public UnitySceneManager(MonoBehaviour coroutineDispatcher)
        {
            this.coroutineDispatcher = coroutineDispatcher;
            this.allowSceneActivation = true;
        }

        public void LoadSceneAsync(string sceneName)
        {
            if (this.loadingCoroutine != null)
            {
                return;
            }
            
            this.loadingCoroutine = this.coroutineDispatcher.StartCoroutine(this.LoadSceneRoutine(sceneName));
        }

        public void AllowSceneActivation(bool isAllowed)
        {
            this.allowSceneActivation = isAllowed;
            if (this.loadingOperation != null)
            {
                this.loadingOperation.allowSceneActivation = isAllowed;
            }
        }

        public float GetLoadingProgress()
        {
            if (this.loadingOperation != null)
            {
                return this.loadingOperation.progress;
            }

            return 1.0f;
        }
        
        public bool IsLoading()
        {
            if (this.loadingOperation != null)
            {
                return !this.loadingOperation.isDone;
            }

            return true;
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            this.loadingOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            this.loadingOperation.allowSceneActivation = this.allowSceneActivation;
            
            while (!this.loadingOperation.isDone)
            {
                yield return null;
            }

            this.loadingOperation = null;
            this.loadingCoroutine = null; 
        }
    }


//
// public class SceneManager : MonoBehaviour, ISceneManager
// {
//     public Slider ProgressBarSlider;
//     public GameObject VisualPart;
//     public float FakeLoadTime = 1f;
//
//     private void Awake()
//     {
//      
//         DontDestroyOnLoad(gameObject);
//         VisualPart.SetActive(false);
//     }
//   
//     public void LoadSceneAsync(string sceneName)
//     {
//         StartCoroutine(LoadGameSceneCor(sceneName));
//     }
//
//     private IEnumerator LoadGameSceneCor(string sceneName)
//     {
//         VisualPart.SetActive(true);
//         AsyncOperation asyncLoading = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
//         asyncLoading.allowSceneActivation = false;
//
//         float timer = 0;
//
//         while (timer < FakeLoadTime || asyncLoading.progress < 0.9f)
//         {
//             timer += Time.deltaTime;
//             SetProgressBarProgress(timer / FakeLoadTime);
//
//             yield return null;
//         }
//
//         asyncLoading.allowSceneActivation = true;
//
//         while (!asyncLoading.isDone)
//             yield return null;
//         VisualPart.SetActive(false);
//     }
//
//     private void SetProgressBarProgress(float progress)
//     {
//         ProgressBarSlider.value = progress;
//     }
// }