using System;

namespace FlashlightSystem
{
    public class FlashlightController
    {
        private readonly FlashlightView _flashlightView;

        public FlashlightController(FlashlightView flashlightView)
        {
            _flashlightView = flashlightView != null ? flashlightView : throw new ArgumentNullException(nameof(flashlightView));
        }

        public void SwitchFlashlightToNextMode()
        {
            if (_flashlightView.CurrentModeIndex == _flashlightView.LastModeIndex)
                return;

            _flashlightView.SwitchFlashlightMode(_flashlightView.CurrentModeIndex + 1);
        }

        public void SwitchFlashlightToPreviousMode()
        {
            if (_flashlightView.CurrentModeIndex == -1)
                return;

            _flashlightView.SwitchFlashlightMode(_flashlightView.CurrentModeIndex - 1);
        }
    }
}
