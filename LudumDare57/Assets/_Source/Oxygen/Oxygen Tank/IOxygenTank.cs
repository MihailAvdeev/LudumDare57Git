using System;

namespace OxygenTankSystem
{
    public interface IOxygenTank
    {
        public int MaxOxygenAmount { get; }
        public int OxygenAmount { get; set; }

        public event Action<int> OnOxygenAmountChanged;
    }
}
