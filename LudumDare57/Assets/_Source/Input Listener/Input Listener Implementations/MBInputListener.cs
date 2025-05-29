using DecoyUserSystem;
using FlashlightSystem;
using GameSystem.Pause;
using InteractionSystem;
using MovementSystem;
using PlayerControlsProviderSystem;
using UnityEngine;

namespace InputActionsManagerSystem
{
    public class MBInputListener : MonoBehaviour
    {
        [SerializeField] private MBMovementController movementController;
        [SerializeField] private MBLookController lookController;
        [SerializeField] private MBInteractionController interactionController;
        [SerializeField] private MBFlashlight flashlight;
        [SerializeField] private MBGamePauseController gamePauseController;
        [SerializeField] private MBDecoySpawnerUser decoyUser;

        [Space]
        [SerializeField] private MBPlayerControlsProvider playerControlsProvider;

        private InputListener _inputListener;

        private void Start()
        {
            _inputListener = new(movementController, lookController, interactionController, flashlight, gamePauseController, decoyUser);

            _inputListener.SetupInputActions(playerControlsProvider.PlayerControls);
        }
    }
}