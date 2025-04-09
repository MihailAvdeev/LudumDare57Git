using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GamePauseMenu : AMenu
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button settingsButton;

        public event Action OnResumeButtonClicked;
        public event Action OnQuitButtonClicked;

        protected override void OnMenuOpened()
        {
            resumeButton.onClick.AddListener(InvokeResumeButtonEvent);
            quitButton.onClick.AddListener(InvokeQuitButtonEvent);
        }

        protected override void OnMenuclosed()
        {
            resumeButton.onClick.RemoveListener(InvokeResumeButtonEvent);
            quitButton.onClick.RemoveListener(InvokeQuitButtonEvent);
        }

        private void InvokeResumeButtonEvent()
        {
            OnResumeButtonClicked?.Invoke();
        }

        private void InvokeQuitButtonEvent()
        {
            OnQuitButtonClicked?.Invoke();
        }
    }
}
