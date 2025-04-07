using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GameLossMenu : AMenu
    {
        [SerializeField] private Button restartGameButton;

        public event Action OnRestartButtonClicked;

        protected override void OnMenuOpened()
        {
            restartGameButton.onClick.AddListener(InvokeRestartButtonEvent);
        }

        protected override void OnMenuclosed()
        {
            restartGameButton.onClick.RemoveListener(InvokeRestartButtonEvent);
        }

        private void InvokeRestartButtonEvent()
        {
            OnRestartButtonClicked?.Invoke();
        }
    }
}
