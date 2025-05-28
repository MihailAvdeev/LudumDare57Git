using UnityEngine;

namespace PlayerControlsProviderSystem
{
    public class MBPlayerControlsProvider : MonoBehaviour
    {
        private PlayerControls _playerControls;

        public PlayerControls PlayerControls
        {
            get
            {
                _playerControls ??= new();

                return _playerControls;
            }
        }
    }
}
