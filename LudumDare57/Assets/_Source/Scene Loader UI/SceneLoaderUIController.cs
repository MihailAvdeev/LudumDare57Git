using SceneLoaderSystem;
using System;

namespace SceneLoaderUISystem
{
    public class SceneLoaderUIController
    {
        private readonly LoadingScreen _loadingScreen;

        private ISceneLoader _sceneLoader;

        public SceneLoaderUIController(LoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen != null ? loadingScreen : throw new ArgumentNullException(nameof(loadingScreen));
        }

        public void DisplaySceneLoader(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));

            _sceneLoader.OnLoadingStarted += _loadingScreen.Show;
            _sceneLoader.OnLoadingProgressChanged += _loadingScreen.DisplayLoadingProgress;
        }

        public void HideSceneLoader()
        {
            if (_sceneLoader == null)
                return;

            _sceneLoader.OnLoadingStarted -= _loadingScreen.Show;
            _sceneLoader.OnLoadingProgressChanged -= _loadingScreen.DisplayLoadingProgress;

            _sceneLoader = null;
        }
    }
}
