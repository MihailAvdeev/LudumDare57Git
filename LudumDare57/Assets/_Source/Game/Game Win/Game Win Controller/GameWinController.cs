using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.GameWin
{
    public class GameWinController
    {
        private readonly GameWinMenu _menu;

        private readonly IInputActionsManager _inputActionsManager;

        public GameWinController(GameWinMenu menu, IInputActionsManager inputActionsManager)
        {
            _menu = menu != null ? menu : throw new ArgumentNullException(nameof(menu));
            _inputActionsManager = inputActionsManager ?? throw new ArgumentNullException(nameof(inputActionsManager));
        }

        public event Action OnGameWon;

        public void WinGame()
        {
            Time.timeScale = 0f;

            _inputActionsManager.DisableMovementInput();
            _inputActionsManager.DisableFlashlightInput();
            _inputActionsManager.DisableInteractionInput();
            _inputActionsManager.DisablePauseInput();
            _inputActionsManager.DisableDecoyInput();

            _menu.OpenMenu();

            OnGameWon?.Invoke();
        }
    }
}
