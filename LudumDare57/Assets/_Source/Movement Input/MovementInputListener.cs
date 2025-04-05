using MovementSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementInputSystem
{
    public class MovementInputListener
    {
        private readonly MovementController _movementController;
        private readonly LookController _lookController;

        public MovementInputListener(PlayerControls.MovementActions movementActions, MovementController movementController, LookController lookController)
        {
            _movementController = movementController != null ? movementController : throw new ArgumentNullException(nameof(movementController));
            _lookController = lookController != null ? lookController : throw new ArgumentNullException(nameof(lookController));

            #region Input Actions
            movementActions.Move.started += OnMoveInput;
            movementActions.Move.performed += OnMoveInput;
            movementActions.Move.canceled += OnMoveInput;

            movementActions.Look.started += OnLookInput;
            movementActions.Look.performed += OnLookInput;
            movementActions.Look.canceled += OnLookInput;
            #endregion
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
    }
}
