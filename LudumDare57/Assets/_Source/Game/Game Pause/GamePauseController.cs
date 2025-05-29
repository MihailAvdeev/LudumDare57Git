using ClosableUISystem;
using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.Pause
{
    public class GamePauseController : IGamePauseController
    {
        private readonly IClosableUI _gamePauseMenu;

        private readonly IInputActionsManager _inputActionsManager;

        public GamePauseController(IClosableUI gamePauseMenu, IInputActionsManager inputActionsManager)
        {
            _gamePauseMenu = gamePauseMenu ?? throw new ArgumentNullException(nameof(gamePauseMenu));
            _inputActionsManager = inputActionsManager ?? throw new ArgumentNullException(nameof(inputActionsManager));
        }

        public bool IsPaused { get; private set; }

        public event Action OnGamePaused;
        public event Action OnGameUnpaused;

        public void PauseGame()
        {
            if (IsPaused)
                return;
            IsPaused = true;

            Time.timeScale = 0.0f;

            _inputActionsManager.DisableMovementInput();
            _inputActionsManager.DisableFlashlightInput();
            _inputActionsManager.DisableInteractionInput();
            _inputActionsManager.DisableDecoyInput();

            _gamePauseMenu.Open();

            OnGamePaused?.Invoke();
        }

        public void UnpauseGame()
        {
            if (!IsPaused)
                return;
            IsPaused = false;

            Time.timeScale = 1.0f;

            _inputActionsManager.EnableMovementInput();
            _inputActionsManager.EnableFlashlightInput();
            _inputActionsManager.EnableInteractionInput();
            _inputActionsManager.EnableDecoyInput();

            _gamePauseMenu.Close();

            OnGameUnpaused?.Invoke();
        }
    }
}
