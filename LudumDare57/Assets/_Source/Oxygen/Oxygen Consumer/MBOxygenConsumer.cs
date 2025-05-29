using OxygenTankSystem;
using System;
using UnityEngine;

namespace OxygenConsumerSystem
{
    public class MBOxygenConsumer : MonoBehaviour, IOxygenConsumer
    {
        [SerializeField] private float inhalesInterval;
        [SerializeField] private MBOxygenTank oxygenTank;

        private OxygenConsumer _oxygenConsumer;

        private OxygenConsumer OxygenConsumer
        {
            get
            {
                _oxygenConsumer ??= new(inhalesInterval, oxygenTank, this);

                return _oxygenConsumer;
            }
        }

        public event Action OnSuffocationStarted { add { OxygenConsumer.OnSuffocationStarted += value; } remove { OxygenConsumer.OnSuffocationStarted -= value; } }

        public void StartConsuming()
        {
            OxygenConsumer.StartConsuming();
        }
    }
}
