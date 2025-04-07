using FlashlightSystem;
using InteractionSystem;
using MovementSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener
    {
        private readonly MovementController _movementController;
        private readonly LookController _lookController;
        private readonly InteractionController _interactionController;
        private readonly FlashlightController _flashlightController;

        public InputListener(MovementController movementController,
                             LookController lookController,
                             InteractionController interactionController,
                             FlashlightController flashlightController)
        {
            _movementController = movementController != null ? movementController : throw new ArgumentNullException(nameof(movementController));
            _lookController = lookController != null ? lookController : throw new ArgumentNullException(nameof(lookController));
            _interactionController = interactionController ?? throw new ArgumentNullException(nameof(interactionController));
            _flashlightController = flashlightController ?? throw new ArgumentNullException(nameof(flashlightController));
        }

        public void SetupInputActions(PlayerControls playerControls)
        {
            playerControls.Movement.Move.started += OnMoveInput;
            playerControls.Movement.Move.performed += OnMoveInput;
            playerControls.Movement.Move.canceled += OnMoveInput;

            playerControls.Movement.Look.started += OnLookInput;
            playerControls.Movement.Look.performed += OnLookInput;
            playerControls.Movement.Look.canceled += OnLookInput;

            playerControls.Interaction.Interact.performed += OnInteractInput;

            playerControls.Flashlight.SwitchMode.performed += OnSwitchModeInput;
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
                _flashlightController.SwitchFlashlightToNextMode();
            }
            else if (input < 0f)
            {
                _flashlightController.SwitchFlashlightToPreviousMode();
            }
        }

    }
}