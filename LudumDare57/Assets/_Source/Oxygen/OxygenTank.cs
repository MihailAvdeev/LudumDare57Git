using System;

namespace OxygenSystem
{
    public class OxygenTank
    {
        private int _oxygenAmount;

        public OxygenTank(int maxOxygenAmount)
        {
            MaxOxygenAmount = maxOxygenAmount;
        }

        public int OxygenAmount { get { return _oxygenAmount; } set { SetOxygenAmount(value); } }
        public int MaxOxygenAmount { get; }

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
