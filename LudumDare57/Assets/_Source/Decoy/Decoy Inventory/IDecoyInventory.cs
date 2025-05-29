using System;

namespace DecoyInventorySystem
{
    public interface IDecoyInventory
    {
        public int MaxDecoysCount { get; set; }
        public int StoredDecoysCount { get; set; }

        public event Action<int> OnMaxDecoysCountChanched;
        public event Action<int> OnStoredDecoysCountChanged;
    }
}
