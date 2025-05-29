using InputActionsManagerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystem.GameLoss
{
    public class MBGameLossController : MonoBehaviour, IGameLossController
    {
        [SerializeField] private GameLossMenu gameLossMenu;
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
