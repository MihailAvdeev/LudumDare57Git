using InputActionsManagerSystem;
using SceneLoaderSystem;
using System;

namespace SceneTransitionSystem
{
    public class SceneTransition : ISceneTransition
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly string _sceneName;

        private readonly IInputActionsManager _inputActionsManager;

        public SceneTransition(ISceneLoader sceneLoader, string sceneName, IInputActionsManager inputActionsManager)
        {
            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));
            _sceneName = sceneName ?? throw new ArgumentNullException(nameof(sceneName));
            _inputActionsManager = inputActionsManager ?? throw new ArgumentNullException(nameof(inputActionsManager));
        }

        public void ExecuteTransition()
        {
            _sceneLoader.LoadScene(_sceneName);

            _inputActionsManager.DisableMovementInput();
            _inputActionsManager.DisableFlashlightInput();
            _inputActionsManager.DisableInteractionInput();
            _inputActionsManager.DisablePauseInput();
            _inputActionsManager.DisableDecoyInput();
        }
    }
}
