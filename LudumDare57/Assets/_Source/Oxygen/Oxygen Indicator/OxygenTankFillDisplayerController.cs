using FillDisplayerSystem;
using OxygenTankSystem;
using System;

namespace OxygenTankUISystem
{
    public class OxygenTankFillDisplayerController
    {
        private readonly AMBFillDisplayer _oxygenTankFillDisplayer;

        private IOxygenTank _displayedOxygenTank;

        public OxygenTankFillDisplayerController(AMBFillDisplayer oxygenTankFillDisplayer)
        {
            _oxygenTankFillDisplayer = oxygenTankFillDisplayer != null ? oxygenTankFillDisplayer : throw new ArgumentNullException(nameof(oxygenTankFillDisplayer));
        }

        public void DisplayOxygenTank(IOxygenTank oxygenTank)
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
            _oxygenTankFillDisplayer.DisplayFill(0f);
        }

        private void DisplayOxygenAmountChange(int oxygenAmountChange)
        {
            DisplayOxygenAmount();
        }

        private void DisplayOxygenAmount()
        {
            if (_displayedOxygenTank != null)
                _oxygenTankFillDisplayer.DisplayFill((float)_displayedOxygenTank.OxygenAmount / _displayedOxygenTank.MaxOxygenAmount);
        }
    }
}
