using PlayerControlsProviderSystem;
using UnityEngine;

namespace InputActionsManagerSystem
{
    public class MBInputActionsManager : MonoBehaviour, IInputActionsManager
    {
        [SerializeField] private MBPlayerControlsProvider playerControlsProvider;

        private InputActionsManager _inputActionsManager;

        private InputActionsManager InputActionsManager
        {
            get
            {
                _inputActionsManager ??= new(playerControlsProvider.PlayerControls);

                return _inputActionsManager;
            }
        }

        public void DisableDecoyInput()
        {
            InputActionsManager.DisableDecoyInput();
        }

        public void DisableFlashlightInput()
        {
            InputActionsManager.DisableFlashlightInput();
        }

        public void DisableInteractionInput()
        {
            InputActionsManager.DisableInteractionInput();
        }

        public void DisableMovementInput()
        {
            InputActionsManager.DisableMovementInput();
        }

        public void DisablePauseInput()
        {
            InputActionsManager.DisablePauseInput();
        }

        public void EnableDecoyInput()
        {
            InputActionsManager.EnableDecoyInput();
        }

        public void EnableFlashlightInput()
        {
            InputActionsManager.EnableFlashlightInput();
        }

        public void EnableInteractionInput()
        {
            InputActionsManager.EnableInteractionInput();
        }

        public void EnableMovementInput()
        {
            InputActionsManager.EnableMovementInput();
        }

        public void EnablePauseInput()
        {
            InputActionsManager.EnablePauseInput();
        }
    }
}
