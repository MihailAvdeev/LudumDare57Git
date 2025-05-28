using System;

namespace OxygenTankSystem
{
    public class OxygenTank : IOxygenTank
    {
        private int _oxygenAmount;

        internal OxygenTank(int maxOxygenAmount)
        {
            MaxOxygenAmount = maxOxygenAmount;
        }

        public int MaxOxygenAmount { get; }
        public int OxygenAmount { get { return _oxygenAmount; } set { SetOxygenAmount(value); } }

        public event Action<int> OnOxygenAmountChanged;

        private void SetOxygenAmount(int value)
        {
            if (value < 0)
                value = 0;

            if (value > MaxOxygenAmount)
                value = MaxOxygenAmount;

            int oxygenAmountChange = value - _oxygenAmount;
            _oxygenAmount = value;
            OnOxygenAmountChanged?.Invoke(oxygenAmountChange);
        }
    }
}
