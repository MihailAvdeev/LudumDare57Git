using OxygenConsumerSystem;
using System;
using UnityEngine;

namespace OxygenTankSystem
{
    public class MBOxygenTank : MonoBehaviour, IOxygenTank
    {
        [SerializeField] private OxygenTankConfiguration configuration;

        private OxygenTank _oxygenTank;

        public int MaxOxygenAmount => OxygenTank.MaxOxygenAmount;

        public int OxygenAmount { get => OxygenTank.OxygenAmount; set => OxygenTank.OxygenAmount = value; }

        private OxygenTank OxygenTank
        {
            get
            {
                _oxygenTank ??= configuration.CreateOxygenTank;

                return _oxygenTank;
            }
        }

        public event Action<int> OnOxygenAmountChanged { add { OxygenTank.OnOxygenAmountChanged += value; } remove { OxygenTank.OnOxygenAmountChanged -= value; } }
    }
}
