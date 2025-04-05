using FlashlightSystem;
using System;
using UnityEngine.InputSystem;

namespace FlashlightInputSystem
{
    public class FlashlightInputListener
    {
        private readonly FlashlightController _flashlightController;

        public FlashlightInputListener(PlayerControls.FlashlightActions flashlightActions, FlashlightController flashlightController)
        {
            _flashlightController = flashlightController ?? throw new ArgumentNullException(nameof(flashlightController));

            flashlightActions.SwitchMode.performed += OnSwitchModeInput;
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