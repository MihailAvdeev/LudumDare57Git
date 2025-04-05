using CustomUtilities;
using System;
using System.Collections;
using UnityEngine;

namespace OxygenSystem
{
    public class OxygenConsumer
    {
        private readonly float _inhalesInterval;

        private readonly OxygenTank _oxygenTank;

        public OxygenConsumer(float inhalesInterval, OxygenTank oxygenTank, CoroutineManager coroutineManager)
        {
            if (coroutineManager == null) throw new ArgumentNullException(nameof(coroutineManager));

            _inhalesInterval = inhalesInterval;
            _oxygenTank = oxygenTank ?? throw new ArgumentNullException(nameof(oxygenTank));

            coroutineManager.StartCoroutine(ConsumingOxygen());
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
                    Debug.Log("Inhale");

                    timer -= _inhalesInterval;

                    if (_oxygenTank.OxygenAmount > 0)
                    {
                        _oxygenTank.OxygenAmount -= 1;
                    }
                    else
                    {
                        Debug.Log("Suffocating!");
                    }
                }
            }
        }
    }
}
