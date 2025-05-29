using ClosableUISystem;
using InputActionsManagerSystem;
using System;
using UnityEngine;

namespace GameSystem.GameWin
{
    public class MBGameWinController : MonoBehaviour, IGameWinController
    {
        [SerializeField] private AMBClosableUI gameWinMenu;
        [SerializeField] private MBInputActionsManager inputActionsManager;

        private GameWinController _gameWinController;

        private GameWinController GameWinController
        {
            get
            {
                _gameWinController ??= new(gameWinMenu, inputActionsManager);

                return _gameWinController;
            }
        }

        public event Action OnGameWon { add { GameWinController.OnGameWon += value; } remove { GameWinController.OnGameWon -= value; } }

        public void WinGame()
        {
            GameWinController.WinGame();
        }
    }
}
