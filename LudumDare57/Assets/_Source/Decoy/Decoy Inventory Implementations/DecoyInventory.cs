using System;
using UnityEngine;

namespace DecoyInventorySystem
{
    public class DecoyInventory : IDecoyInventory
    {
        private int _storedDecoysCount;
        private int _maxDecoysCount;

        public int MaxDecoysCount
        {
            get
            {
                return _maxDecoysCount;
            }
            set
            {
                _maxDecoysCount = value;
                OnMaxDecoysCountChanched?.Invoke(value);
            }
        }

        public int StoredDecoysCount { get { return _storedDecoysCount; } set { SetStoredDecoys(value); } }

        public event Action<int> OnMaxDecoysCountChanched;
        public event Action<int> OnStoredDecoysCountChanged;

        private void SetStoredDecoys(int decoys)
        {
            if (decoys < 0)
            {
                Debug.Log("Setting stored decoys to negative is not possible. Will set to 0 instead.");
                decoys = 0;
            }

            if (decoys > MaxDecoysCount)
            {
                Debug.Log("Setting stored decoys to more than max number is not possible. Will set to max number instead.");
                decoys = MaxDecoysCount;
            }

            _storedDecoysCount = decoys;
            OnStoredDecoysCountChanged?.Invoke(decoys);
        }
    }
}
