using OxygenSystem;
using System;
using UnityEngine;

namespace GameSystem
{
    public class GameStartController
    {
        private readonly GameObject _player;
        private readonly Transform _startPoint;
        private readonly GameStartMenu _gameStartMenu;
        private readonly AMenu _gamePauseMenu;
        private readonly GameLossMenu _gameLossMenu;
        private readonly AMenu _gameWinMenu;

        private readonly OxygenTank _oxygenTank;

        public GameStartController(GameObject player,
                                   Transform startPoint,
                                   GameStartMenu gameStartMenu,
                                   AMenu gamePauseMenu,
                                   GameLossMenu gameLossMenu,
                                   AMenu gameWinMenu,
                                   OxygenTank oxygenTank)
        {
            _player = player != null ? player : throw new ArgumentNullException(nameof(player));
            _startPoint = startPoint != null ? startPoint : throw new ArgumentNullException(nameof(startPoint));
            _gameStartMenu = gameStartMenu != null ? gameStartMenu : throw new ArgumentNullException(nameof(gameStartMenu));
            _gamePauseMenu = gamePauseMenu != null ? gamePauseMenu : throw new ArgumentNullException(nameof(gamePauseMenu));
            _gameLossMenu = gameLossMenu != null ? gameLossMenu : throw new ArgumentNullException(nameof(gameLossMenu));
            _gameWinMenu = gameWinMenu != null ? gameWinMenu : throw new ArgumentNullException(nameof(gameWinMenu));
            _oxygenTank = oxygenTank ?? throw new ArgumentNullException(nameof(oxygenTank));
        }

        public void StartGame()
        {
            _player.transform.position = _startPoint.position;
            _player.SetActive(true);
            
            _gameStartMenu.CloseMenu();
            _gamePauseMenu.CloseMenu();
            _gameLossMenu.CloseMenu();
            _gameWinMenu.CloseMenu();

            _oxygenTank.OxygenAmount = 30;

            Time.timeScale = 1.0f;
        }
    }
}
