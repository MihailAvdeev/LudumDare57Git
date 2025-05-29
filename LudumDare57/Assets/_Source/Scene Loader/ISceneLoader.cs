using System;

namespace SceneLoaderSystem
{
    public interface ISceneLoader
    {
        public bool IsLoadingScene { get; }
        public float LoadingProgress { get; }

        public event Action OnLoadingStarted;
        public event Action OnLoadingFinished;
        public event Action<float> OnLoadingProgressChanged;

        public void LoadScene(string sceneName);
    }
}
