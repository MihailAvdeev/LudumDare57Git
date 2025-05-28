using System;

namespace InputActionsManagerSystem
{
    public class InputActionsManager : IInputActionsManager
    {
        private readonly PlayerControls _inputActions;

        public InputActionsManager(PlayerControls inputActions)
        {
            _inputActions = inputActions ?? throw new ArgumentNullException(nameof(inputActions));
        }

        #region Movement
        public void DisableMovementInput()
        {
            _inputActions.Movement.Disable();
        }

        public void EnableMovementInput()
        {
            _inputActions.Movement.Enable();
        }
        #endregion

        #region Flashlight
        public void DisableFlashlightInput()
        {
            _inputActions.Flashlight.Disable();
        }

        public void EnableFlashlightInput()
        {
            _inputActions.Flashlight.Enable();
        }
        #endregion

        #region Interaction
        public void DisableInteractionInput()
        {
            _inputActions.Interaction.Disable();
        }

        public void EnableInteractionInput()
        {
            _inputActions.Interaction.Enable();
        }
        #endregion

        #region Pause
        public void DisablePauseInput()
        {
            _inputActions.Pause.Disable();
        }

        public void EnablePauseInput()
        {
            _inputActions.Pause.Enable();
        }
        #endregion

        #region Decoy
        public void DisableDecoyInput()
        {
            _inputActions.Decoy.Disable();
        }

        public void EnableDecoyInput()
        {
            _inputActions.Decoy.Enable();
        }
        #endregion
    }
}
