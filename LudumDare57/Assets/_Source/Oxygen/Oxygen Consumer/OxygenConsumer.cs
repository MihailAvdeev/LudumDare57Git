using OxygenTankSystem;
using System;
using System.Collections;
using UnityEngine;

namespace OxygenConsumerSystem
{
    public class OxygenConsumer : IOxygenConsumer
    {
        private readonly float _inhalesInterval;
        private readonly IOxygenTank _oxygenTank;
        private readonly MonoBehaviour _monoBehaviour;

        public OxygenConsumer(float inhalesInterval, IOxygenTank oxygenTank, MonoBehaviour monoBehaviour)
        {
            if (monoBehaviour == null) throw new ArgumentNullException(nameof(monoBehaviour));

            _inhalesInterval = inhalesInterval;
            _oxygenTank = oxygenTank ?? throw new ArgumentNullException(nameof(oxygenTank));
            _monoBehaviour = monoBehaviour != null ? monoBehaviour : throw new ArgumentNullException(nameof(monoBehaviour));
        }

        public event Action OnSuffocationStarted;

        public void StartConsuming()
        {
            _monoBehaviour.StartCoroutine(ConsumingOxygen());
        }

        private IEnumerator ConsumingOxygen()
        {
            float timer = 0f;

            while (true)
            {
                yield return null;

                timer += Time.deltaTime;

                if (timer >= _inhalesInterval)
                {
                    timer -= _inhalesInterval;

                    if (_oxygenTank.OxygenAmount > 0)
                    {
                        _oxygenTank.OxygenAmount -= 1;
                    }
                    else
                    {
                        OnSuffocationStarted?.Invoke();
                    }
                }
            }
        }
    }
}
