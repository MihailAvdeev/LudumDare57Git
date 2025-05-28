namespace InputActionsManagerSystem
{
    public interface IInputActionsManager
    {
        #region Movement
        public void DisableMovementInput();

        public void EnableMovementInput();
        #endregion

        #region Flashlight
        public void DisableFlashlightInput();

        public void EnableFlashlightInput();
        #endregion

        #region Interaction
        public void DisableInteractionInput();

        public void EnableInteractionInput();
        #endregion

        #region Pause
        public void DisablePauseInput();

        public void EnablePauseInput();
        #endregion

        #region Decoy
        public void DisableDecoyInput();

        public void EnableDecoyInput();
        #endregion
    }
}
