using CountDisplayerSystem;
using DecoyInventorySystem;
using UnityEngine;

namespace DecoyInventoryUISystem
{
    public class MBCountDisplayersDecoyInventoryDisplayer : AMBDecoyInventoryDisplayer
    {
        [SerializeField] private AMBCountDisplayer maxDecoysCountDisplayer;
        [SerializeField] private AMBCountDisplayer storedDecoysCountDisplayer;

        protected override void DisplayDecoyInventory(IDecoyInventory decoyInventory)
        {
            maxDecoysCountDisplayer.DisplayCount(decoyInventory.MaxDecoysCount);
            decoyInventory.OnMaxDecoysCountChanched += maxDecoysCountDisplayer.DisplayCount;

            storedDecoysCountDisplayer.DisplayCount(decoyInventory.StoredDecoysCount);
            decoyInventory.OnStoredDecoysCountChanged += storedDecoysCountDisplayer.DisplayCount;
        }
    }
}
