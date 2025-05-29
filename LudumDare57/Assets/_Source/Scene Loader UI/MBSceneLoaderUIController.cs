using SceneLoaderSystem;
using UnityEngine;

namespace SceneLoaderUISystem
{
    public class MBSceneLoaderUIController : MonoBehaviour
    {
        [SerializeField] private MBSceneLoader sceneLoader;
        [SerializeField] private LoadingScreen loadingScreen;

        private void Start()
        {
            SceneLoaderUIController sceneLoaderUIController = new(loadingScreen);
            sceneLoaderUIController.DisplaySceneLoader(sceneLoader);
        }
    }
}
