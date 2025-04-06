using InteractionSystem;
using System;
using UnityEngine.InputSystem;

namespace InteractionInputSystem
{
    public class InteractionInputListener
    {
        private readonly InteractionController _interactionController;

        public InteractionInputListener(PlayerControls.InteractionActions interactionActions, InteractionController interactionController)
        {
            _interactionController = interactionController ?? throw new ArgumentNullException(nameof(interactionController));

            interactionActions.Interact.performed += OnInteractInput;
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            _interactionController.Interact();
        }
    }
}
