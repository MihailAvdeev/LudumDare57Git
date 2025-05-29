using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class GameStartMenu : AMenu
    {
        [SerializeField] private Button startGameButton;

        public event Action OnStartButtonClicked;

        protected override void OnMenuOpened()
        {
            startGameButton.onClick.AddListener(InvokeStartButtonEvent);
        }

        protected override void OnMenuclosed()
        {
            startGameButton.onClick.RemoveListener(InvokeStartButtonEvent);
        }

        private void InvokeStartButtonEvent()
        {
            OnStartButtonClicked?.Invoke();
        }
    }
}
