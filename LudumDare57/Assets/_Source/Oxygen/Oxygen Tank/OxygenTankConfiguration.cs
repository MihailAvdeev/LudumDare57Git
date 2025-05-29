using OxygenTankSystem;
using System;
using UnityEngine;

namespace OxygenConsumerSystem
{
    [Serializable]
    public class OxygenTankConfiguration
    {
        [SerializeField] private int maxOxygenAmount;

        public OxygenTank CreateOxygenTank { get { return new(maxOxygenAmount); } }
    }
}
