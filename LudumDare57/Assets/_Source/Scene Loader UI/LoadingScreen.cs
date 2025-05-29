using FillDisplayerSystem;
using ClosableUISystem;
using UnityEngine;

namespace SceneLoaderUISystem
{
    public class LoadingScreen : AMBClosableUI
    {
        [SerializeField] private AMBFillDisplayer[] fillDisplayers = new AMBFillDisplayer[0];

        public void DisplayLoadingProgress(float loadingProgress)
        {
            foreach (var fillDisplayer in fillDisplayers)
            {
                fillDisplayer.DisplayFill(loadingProgress);
            }
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }

        public override void Open()
        {
            gameObject.SetActive(true);
        }
    }
}
