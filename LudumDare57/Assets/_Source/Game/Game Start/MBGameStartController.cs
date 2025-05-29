using ClosableUISystem;
using FlashlightSystem;
using InputActionsManagerSystem;
using OxygenConsumerSystem;
using OxygenTankSystem;
using System;
using UnityEngine;

namespace GameSystem.GameStart
{
    public class MBGameStartController : MonoBehaviour, IGameStartController
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Transform startPoint;
        [SerializeField] private AMBClosableUI gameStartMenu;
        [SerializeField] private MBOxygenTank oxygenTank;
        [SerializeField] private MBOxygenConsumer oxygenConsumer;
        [SerializeField] private MBFlashlight flashlight;
        [SerializeField] private MBInputActionsManager inputActionsManager;

        [Space]
        [SerializeField] private GameStartConfiguration gameStartConfiguration;

        private GameStartController _gameStartController;

        private GameStartController GameStartController
        {
            get
            {
                _gameStartController ??= new(player, startPoint, gameStartMenu, oxygenTank, oxygenConsumer, flashlight, inputActionsManager, gameStartConfiguration);

                return _gameStartController;
            }
        }

        public event Action OnGameStarted { add { GameStartController.OnGameStarted += value; } remove { GameStartController.OnGameStarted -= value; } }

        public void StartGame()
        {
            GameStartController.StartGame();
        }
    }
}
