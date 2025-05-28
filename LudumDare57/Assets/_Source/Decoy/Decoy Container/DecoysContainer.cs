using DecoyInventorySystem;
using InteractionSystem;
using UnityEngine;

namespace DecoysContainerSystem
{
    public class DecoysContainer : MonoBehaviour, IInteractable
    {
        [Header("Effects")]
        [SerializeField] private AudioClip lootDecoysClip;
        [SerializeField] private GameObject interactionIndicator;

        [Space]
        [SerializeField] private MBDecoyInventory decoyContainerInventory;

        public void ShowInteraction()
        {
            if (decoyContainerInventory.StoredDecoysCount > 0)
                interactionIndicator.SetActive(true);
        }

        public void HideInteraction()
        {
            interactionIndicator.SetActive(false);
        }

        public void Interact(IInteractionData interactionData)
        {
            if (decoyContainerInventory.StoredDecoysCount < 0)
                return;

            if (interactionData.TryGetService(out IDecoyInventory decoyInventory))
            {
                int inventoryCapacity = decoyInventory.MaxDecoysCount - decoyInventory.StoredDecoysCount;

                if (inventoryCapacity > 0)
                {
                    int takenDecoys = inventoryCapacity < decoyContainerInventory.StoredDecoysCount ? inventoryCapacity : decoyContainerInventory.StoredDecoysCount;

                    decoyInventory.StoredDecoysCount += takenDecoys;
                    decoyContainerInventory.StoredDecoysCount -= takenDecoys;

                    if (interactionData.TryGetService(out AudioSource audioSource))
                    {
                        audioSource.PlayOneShot(lootDecoysClip);
                    }
                }
            }
        }
    }
}
