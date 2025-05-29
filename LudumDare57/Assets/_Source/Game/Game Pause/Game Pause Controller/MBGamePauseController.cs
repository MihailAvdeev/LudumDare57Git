using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.Pause
{
    public class MBGamePauseController : MonoBehaviour, IGamePauseController
    {
        [SerializeField] private GamePauseMenu gamePauseMenu;
        [SerializeField] private MBInputActionsManager inputActionsManager;

        private GamePauseController _gamePauseController;

        public bool IsPaused => ((IGamePauseController)GamePauseController).IsPaused;

        private GamePauseController GamePauseController
        {
            get
            {
                _gamePauseController ??= new(gamePauseMenu, inputActionsManager);

                return _gamePauseController;
            }
        }

        public event Action OnGamePaused { add { GamePauseController.OnGamePaused += value; } remove { GamePauseController.OnGamePaused -= value; } }

        public event Action OnGameUnpaused { add { GamePauseController.OnGameUnpaused += value; } remove { GamePauseController.OnGameUnpaused -= value; } }

        public void PauseGame()
        {
            GamePauseController.PauseGame();
        }

        public void UnpauseGame()
        {
            GamePauseController.UnpauseGame();
        }
    }
}
