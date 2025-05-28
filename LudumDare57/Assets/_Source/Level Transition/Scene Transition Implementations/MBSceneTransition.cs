using InputActionsManagerSystem;
using SceneLoaderSystem;
using UnityEngine;

namespace SceneTransitionSystem
{
    public class MBSceneTransition : MonoBehaviour, ISceneTransition
    {
        [SerializeField] private MBSceneLoader sceneLoader;
        [SerializeField] private string sceneName;
        [SerializeField] private MBInputActionsManager inputActionsManager;

        private SceneTransition _sceneTransition;

        private SceneTransition SceneTransition
        {
            get
            {
                _sceneTransition ??= new(sceneLoader, sceneName, inputActionsManager);

                return _sceneTransition;
            }
        }

        public void ExecuteTransition()
        {
            SceneTransition.ExecuteTransition();
        }
    }
}
