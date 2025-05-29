using System;
using UnityEngine;

namespace DecoyInventorySystem
{
    public class MBDecoyInventory : MonoBehaviour, IDecoyInventory
    {
        [SerializeField] private int baseMaxDecoys;
        [SerializeField] protected int startDecoys;

        private DecoyInventory _inventory;

        private DecoyInventory Inventory
        {
            get
            {
                _inventory ??= new()
                {
                    MaxDecoysCount = baseMaxDecoys,
                    StoredDecoysCount = startDecoys
                };

                return _inventory;
            }
        }

        public int MaxDecoysCount { get => Inventory.MaxDecoysCount; set { Inventory.MaxDecoysCount = value; } }
        public int StoredDecoysCount { get => Inventory.StoredDecoysCount; set { Inventory.StoredDecoysCount = value; } }

        public event Action<int> OnMaxDecoysCountChanched { add { Inventory.OnMaxDecoysCountChanched += value; } remove { Inventory.OnMaxDecoysCountChanched -= value; } }
        public event Action<int> OnStoredDecoysCountChanged { add { Inventory.OnStoredDecoysCountChanged += value; } remove { Inventory.OnStoredDecoysCountChanged -= value; } }
    }
}
