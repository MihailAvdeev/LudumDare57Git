using ClosableUISystem;
using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.GameLoss
{
    public class MBGameLossController : MonoBehaviour, IGameLossController
    {
        [SerializeField] private AMBClosableUI gameLossMenu;
        [SerializeField] private MBInputActionsManager inputActionsManager;

        private GameLossController _gameLossController;

        private GameLossController GameLossController
        {
            get
            {
                _gameLossController ??= new(gameLossMenu, inputActionsManager);

                return _gameLossController;
            }
        }

        public event Action OnGameLost { add { GameLossController.OnGameLost += value; } remove { GameLossController.OnGameLost -= value; } }

        public void LoseGame()
        {
            GameLossController.LoseGame();
        }
    }
}
