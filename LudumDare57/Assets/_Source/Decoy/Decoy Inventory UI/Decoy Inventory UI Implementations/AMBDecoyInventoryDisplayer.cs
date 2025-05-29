using DecoyInventorySystem;
using UnityEngine;

namespace DecoyInventoryUISystem
{
    public abstract class AMBDecoyInventoryDisplayer : MonoBehaviour
    {
        [SerializeField] private MBDecoyInventory inventory;

        private void Start()
        {
            DisplayDecoyInventory(inventory);
        }

        protected abstract void DisplayDecoyInventory(IDecoyInventory decoyInventory);
    }
}