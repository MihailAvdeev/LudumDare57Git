using System;
using UnityEngine;

namespace SceneLoaderSystem
{
    public class MBSceneLoader : MonoBehaviour, ISceneLoader
    {
        private SceneLoader _sceneLoader;

        private SceneLoader SceneLoader
        {
            get
            {
                _sceneLoader ??= new(this);

                return _sceneLoader;
            }
        }

        public bool IsLoadingScene { get {  return SceneLoader.IsLoadingScene; } }
        public float LoadingProgress { get { return SceneLoader.LoadingProgress; } }

        public event Action OnLoadingStarted { add { SceneLoader.OnLoadingStarted += value; } remove { SceneLoader.OnLoadingStarted -= value; } }
        public event Action OnLoadingFinished { add { SceneLoader.OnLoadingFinished += value; } remove { SceneLoader.OnLoadingFinished -= value; } }
        public event Action<float> OnLoadingProgressChanged { add {  SceneLoader.OnLoadingProgressChanged += value; } remove { SceneLoader.OnLoadingProgressChanged -= value; } }

        public void LoadScene(string sceneName)
        {
            SceneLoader.LoadScene(sceneName);
        }
    }
}
