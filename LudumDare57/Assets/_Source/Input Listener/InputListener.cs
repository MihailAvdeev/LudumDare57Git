using DecoyUserSystem;
using FlashlightSystem;
using GameSystem.Pause;
using InteractionSystem;
using MovementSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputActionsManagerSystem
{
    public class InputListener
    {
        private readonly IMovementController _movementController;
        private readonly ILookController _lookController;
        private readonly IInteractionController _interactionController;
        private readonly IFlashlight _flashlight;
        private readonly IGamePauseController _gamePauseController;
        private readonly IDecoyUser _decoyUser;

        private PlayerControls _playerControls;

        public InputListener(IMovementController movementController,
                             ILookController lookController,
                             IInteractionController interactionController,
                             IFlashlight flashlight,
                             IGamePauseController gamePauseController,
                             IDecoyUser decoyUser)
        {
            _movementController = movementController ?? throw new ArgumentNullException(nameof(movementController));
            _lookController = lookController ?? throw new ArgumentNullException(nameof(lookController));
            _interactionController = interactionController ?? throw new ArgumentNullException(nameof(interactionController));
            _flashlight = flashlight ?? throw new ArgumentNullException(nameof(flashlight));
            _gamePauseController = gamePauseController ?? throw new ArgumentNullException(nameof(gamePauseController));
            _decoyUser = decoyUser ?? throw new ArgumentNullException(nameof(decoyUser));
        }

        public void SetupInputActions(PlayerControls playerControls)
        {
            _playerControls = playerControls ?? throw new ArgumentNullException(nameof(playerControls));

            _playerControls.Movement.Move.started += OnMoveInput;
            _playerControls.Movement.Move.performed += OnMoveInput;
            _playerControls.Movement.Move.canceled += OnMoveInput;

            _playerControls.Movement.Look.started += OnLookInput;
            _playerControls.Movement.Look.performed += OnLookInput;
            _playerControls.Movement.Look.canceled += OnLookInput;

            _playerControls.Interaction.Interact.performed += OnInteractInput;

            _playerControls.Flashlight.SwitchMode.performed += OnSwitchModeInput;

            _playerControls.Pause.TogglePause.performed += OnPauseInput;

            _playerControls.Decoy.UseDecoy.performed += OnUseDecoyInput;
        }

        public void UnsetupInputActions()
        {
            _playerControls.Movement.Move.started += OnMoveInput;
            _playerControls.Movement.Move.performed += OnMoveInput;
            _playerControls.Movement.Move.canceled += OnMoveInput;

            _playerControls.Movement.Look.started += OnLookInput;
            _playerControls.Movement.Look.performed += OnLookInput;
            _playerControls.Movement.Look.canceled += OnLookInput;

            _playerControls.Interaction.Interact.performed += OnInteractInput;

            _playerControls.Flashlight.SwitchMode.performed += OnSwitchModeInput;

            _playerControls.Pause.TogglePause.performed += OnPauseInput;
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            _movementController.Move(movementInput);
        }

        private void OnLookInput(InputAction.CallbackContext context)
        {
            Vector2 lookInput = context.ReadValue<Vector2>();
            _lookController.LookAt(lookInput);
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            _interactionController.Interact();
        }

        private void OnSwitchModeInput(InputAction.CallbackContext context)
        {
            float input = context.ReadValue<float>();

            if (input > 0f)
            {
                _flashlight.SwitchToNextConfiguration();
            }
            else if (input < 0f)
            {
                _flashlight.SwitchToPreviousConfiguration();
            }
        }

        private void OnPauseInput(InputAction.CallbackContext context)
        {
            if (_gamePauseController.IsPaused)
                _gamePauseController.UnpauseGame();
            else
                _gamePauseController.PauseGame();
        }

        private void OnUseDecoyInput(InputAction.CallbackContext context)
        {
            _decoyUser.UseDecoy();
        }
    }
}