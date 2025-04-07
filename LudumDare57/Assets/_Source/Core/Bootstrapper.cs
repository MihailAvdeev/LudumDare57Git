using CustomUtilities;
using FlashlightSystem;
using GameSystem;
using InputSystem;
using InteractionSystem;
using MovementSystem;
using OxygenSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Transform startPoint;

        [SerializeField] private MovementController movementController;
        [SerializeField] private LookController lookController;

        [Space]
        [SerializeField] private FlashlightView flashlightView;

        [Header("Oxygen")]
        [SerializeField] private OxygenIndicator oxygenTankUIView;

        [Space]
        [SerializeField] private CoroutineManager coroutineManager;

        [Header("Interaction")]
        [SerializeField] private InteractionFinder interactionFinder;
        [SerializeField] private AudioSource interactionAudioSource;

        [Header("Game")]
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameStartMenu gameStartMenu;
        [SerializeField] private GameWinMenu gameWinMenu;
        [SerializeField] private GameLossMenu gameLossMenu;

        [Header("Win")]
        [SerializeField] private Bathyscaphe bathyscaphe;

        private void Start()
        {
            GameWinController gameWinController = new(gameWinMenu);
            bathyscaphe.OnBathyscapheEntered += gameWinController.WinGame;

            GameLossController gameLossController = new(gameLossMenu);

            InteractionData interactionData = new();
            interactionData.TryAddService(interactionAudioSource);
            InteractionController interactionController = new(interactionFinder, interactionData);

            OxygenTank oxygenTank = new(100)
            {
                OxygenAmount = 100
            };
            OxygenConsumer oxygenConsumer = new(0.25f, oxygenTank, coroutineManager);
            oxygenConsumer.OnSuffocationStarted += gameLossController.LoseGame;
            OxygenTankUIController oxygenTankUIController = new(oxygenTankUIView);
            oxygenTankUIController.DisplayOxygenTank(oxygenTank);
            interactionData.TryAddService(oxygenTank);

            GameStartController gameStartController = new(player, startPoint, gameStartMenu, gameLossMenu, gameLossMenu, gameLossMenu, oxygenTank);

            gameStartMenu.OnStartButtonClicked += gameStartController.StartGame;
            gameLossMenu.OnRestartButtonClicked += gameStartController.StartGame;
            gameWinMenu.OnRestartButtonClicked += gameStartController.StartGame;

            gameStartMenu.OpenMenu();

            FlashlightController flashlightController = new(flashlightView);

            PlayerControls playerControls = new();
            playerControls.Movement.Enable();
            playerControls.Flashlight.Enable();
            playerControls.Interaction.Enable();

            InputListener inputListener = new(movementController, lookController, interactionController, flashlightController);
            inputListener.SetupInputActions(playerControls);
        }
    }
}
