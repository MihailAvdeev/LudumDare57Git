using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.GameLoss
{
    public class GameLossController : IGameLossController
    {
        private readonly GameLossMenu _menu;

        private readonly IInputActionsManager _inputActionsManager;

        public GameLossController(GameLossMenu menu, IInputActionsManager inputActionsManager)
        {
            _menu = menu != null ? menu : throw new ArgumentNullException(nameof(menu));
            _inputActionsManager = inputActionsManager ?? throw new ArgumentNullException(nameof(inputActionsManager));
        }

        public event Action OnGameLost;

        public void LoseGame()
        {
            Time.timeScale = 0f;
            
            _inputActionsManager.DisableMovementInput();
            _inputActionsManager.DisableFlashlightInput();
            _inputActionsManager.DisableInteractionInput();
            _inputActionsManager.DisablePauseInput();
            _inputActionsManager.DisableDecoyInput();

            _menu.OpenMenu();

            OnGameLost?.Invoke();
        }
    }
}
