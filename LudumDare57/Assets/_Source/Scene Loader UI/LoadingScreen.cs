using FillDisplayerSystem;
using HidableUISystem;
using UnityEngine;

namespace SceneLoaderUISystem
{
    public class LoadingScreen : AHidableUI
    {
        [SerializeField] private AMBFillDisplayer[] fillDisplayers = new AMBFillDisplayer[0];

        public void DisplayLoadingProgress(float loadingProgress)
        {
            foreach (var fillDisplayer in fillDisplayers)
            {
                fillDisplayer.DisplayFill(loadingProgress);
            }
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
