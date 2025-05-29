using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaderSystem
{
    public class SceneLoader : ISceneLoader
    {
        private readonly MonoBehaviour _monoBehavior;

        public SceneLoader(MonoBehaviour monoBehavior)
        {
            _monoBehavior = monoBehavior != null ? monoBehavior : throw new ArgumentNullException(nameof(monoBehavior));
        }

        public bool IsLoadingScene { get; protected set; } = false;
        public float LoadingProgress { get; protected set; } = 0.0f;

        public event Action OnLoadingStarted;
        public event Action OnLoadingFinished;
        public event Action<float> OnLoadingProgressChanged;

        public void LoadScene(string sceneName)
        {
            _monoBehavior.StartCoroutine(LoadingSceneAsync(sceneName));
        }

        private IEnumerator LoadingSceneAsync(string sceneName)
        {
            if (IsLoadingScene)
                yield break;

            IsLoadingScene = true;
            OnLoadingStarted?.Invoke();

            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);

            while (!loadingScene.isDone)
            {
                float loadingProgress = Mathf.Clamp01(loadingScene.progress / 0.9f);
                OnLoadingProgressChanged?.Invoke(loadingProgress);
                yield return null;
            }

            IsLoadingScene = false;
            OnLoadingFinished?.Invoke();
        }
    }
}