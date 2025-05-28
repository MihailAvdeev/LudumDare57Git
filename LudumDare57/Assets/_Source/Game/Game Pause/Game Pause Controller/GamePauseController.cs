using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.Pause
{
    public class GamePauseController : IGamePauseController
    {
        private readonly GamePauseMenu _menu;

        private readonly IInputActionsManager _inputActionsManager;

        public GamePauseController(GamePauseMenu menu, IInputActionsManager inputActionsManager)
        {
            _menu = menu != null ? menu : throw new ArgumentNullException(nameof(menu));
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

            _menu.OpenMenu();

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

            _menu.CloseMenu();

            OnGameUnpaused?.Invoke();
        }
    }
}
