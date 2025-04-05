using System;

namespace OxygenSystem
{
    public class OxygenTankUIController
    {
        private readonly OxygenTankUIView _oxygenTankUIView;

        private OxygenTank _displayedOxygenTank;

        public OxygenTankUIController(OxygenTankUIView oxygenTankUIView)
        {
            _oxygenTankUIView = oxygenTankUIView != null ? oxygenTankUIView : throw new ArgumentNullException(nameof(oxygenTankUIView));
        }

        public void DisplayOxygenTank(OxygenTank oxygenTank)
        {
            HideOxygenTank();
            _displayedOxygenTank = oxygenTank;
            _displayedOxygenTank.OnOxygenAmountChanged += DisplayOxygenAmountChange;
            DisplayOxygenAmount();
        }

        public void HideOxygenTank()
        {
            if (_displayedOxygenTank == null)
                return;

            _displayedOxygenTank.OnOxygenAmountChanged -= DisplayOxygenAmountChange;
            _displayedOxygenTank = null;
            _oxygenTankUIView.DisplayOxygenTankFill(0f);
        }

        private void DisplayOxygenAmountChange(int oxygenAmountChange)
        {
            DisplayOxygenAmount();
        }

        private void DisplayOxygenAmount()
        {
            if (_displayedOxygenTank != null)
            {
                _oxygenTankUIView.DisplayOxygenTankFill((float)_displayedOxygenTank.OxygenAmount / _displayedOxygenTank.MaxOxygenAmount);
            }
        }
    }
}
