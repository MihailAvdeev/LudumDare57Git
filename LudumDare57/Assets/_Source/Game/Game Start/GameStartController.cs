using ClosableUISystem;
using FlashlightSystem;
using InputActionsManagerSystem;
using OxygenConsumerSystem;
using OxygenTankSystem;
using System;
using UnityEngine;

namespace GameSystem.GameStart
{
    public class GameStartController : IGameStartController
    {
        private readonly GameObject _player;
        private readonly Transform _startPoint;
        private readonly IClosableUI _gameStartMenu;
        private readonly IOxygenTank _oxygenTank;
        private readonly IOxygenConsumer _oxygenConsumer;
        private readonly IFlashlight _flashlightView;
        private readonly IInputActionsManager _inputActionsManager;

        private readonly GameStartConfiguration _gameStartConfiguration;

        public GameStartController(GameObject player,
                                   Transform startPoint,
                                   IClosableUI gameStartMenu,
                                   IOxygenTank oxygenTank,
                                   IOxygenConsumer oxygenConsumer,
                                   IFlashlight flashlightView,
                                   IInputActionsManager inputActionsManager,
                                   GameStartConfiguration gameStartConfiguration)
        {
            _player = player != null ? player : throw new ArgumentNullException(nameof(player));
            _startPoint = startPoint != null ? startPoint : throw new ArgumentNullException(nameof(startPoint));
            _gameStartMenu = gameStartMenu ?? throw new ArgumentNullException(nameof(gameStartMenu));
            _oxygenTank = oxygenTank ?? throw new ArgumentNullException(nameof(oxygenTank));
            _flashlightView = flashlightView ?? throw new ArgumentNullException(nameof(flashlightView));
            _inputActionsManager = inputActionsManager ?? throw new ArgumentNullException(nameof(inputActionsManager));
            _gameStartConfiguration = gameStartConfiguration ?? throw new ArgumentNullException(nameof(gameStartConfiguration));
            _oxygenConsumer = oxygenConsumer ?? throw new ArgumentNullException(nameof(oxygenConsumer));
        }

        public event Action OnGameStarted;

        public void StartGame()
        {
            _player.transform.position = _startPoint.position;
            _player.SetActive(true);

            _gameStartMenu.Close();

            _oxygenTank.OxygenAmount = _gameStartConfiguration.StartOxygen;
            _oxygenConsumer.StartConsuming();

            _flashlightView.SwitchToConfiguration(_gameStartConfiguration.StartFlashlightMode);

            Time.timeScale = 1.0f;

            _inputActionsManager.EnableMovementInput();
            _inputActionsManager.EnableFlashlightInput();
            _inputActionsManager.EnableInteractionInput();
            _inputActionsManager.EnablePauseInput();
            _inputActionsManager.EnableDecoyInput();

            OnGameStarted?.Invoke();
        }
    }
}
