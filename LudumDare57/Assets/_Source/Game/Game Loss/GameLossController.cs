using System;
using UnityEngine;

namespace GameSystem
{
    public class GameLossController
    {
        private readonly GameLossMenu _menu;
        private readonly GameObject _playerObject;

        public GameLossController(GameLossMenu menu, GameObject playerObject)
        {
            _menu = menu != null ? menu : throw new ArgumentNullException(nameof(menu));
            _playerObject = playerObject != null ? playerObject : throw new ArgumentNullException(nameof(playerObject));
        }

        public void LoseGame()
        {
            //Time.timeScale = 0f;
            _playerObject.SetActive(false);
            _menu.OpenMenu();
        }
    }
}
