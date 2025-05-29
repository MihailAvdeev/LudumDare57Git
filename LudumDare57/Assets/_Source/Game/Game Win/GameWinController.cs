using ClosableUISystem;
using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.GameWin
{
    public class GameWinController
    {
        private readonly IClosableUI _gameWinMenu;

        private readonly IInputActionsManager _inputActionsManager;

        public GameWinController(IClosableUI gameWinMenu, IInputActionsManager inputActionsManager)
        {
            _gameWinMenu = gameWinMenu ?? throw new ArgumentNullException(nameof(gameWinMenu));
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

            _gameWinMenu.Open();

            OnGameWon?.Invoke();
        }
    }
}
