using InteractionSystem;
using OxygenTankSystem;
using UnityEngine;

namespace OxygenCylinderSystem
{
    public class OxygenCylinder : MonoBehaviour, IInteractable
    {
        [SerializeField] private AudioClip fillOxygenTankClip;

        [Space]
        [SerializeField] private GameObject interactionIndicator;

        public void ShowInteraction()
        {
            interactionIndicator.SetActive(true);
        }

        public void HideInteraction()
        {
            interactionIndicator.SetActive(false);
        }

        public void Interact(IInteractionData interactionData)
        {
            if (interactionData.TryGetService(out IOxygenTank oxygenTank))
            {
                if (oxygenTank.OxygenAmount < oxygenTank.MaxOxygenAmount)
                {
                    oxygenTank.OxygenAmount = oxygenTank.MaxOxygenAmount;

                    if (interactionData.TryGetService(out AudioSource audioSource))
                    {
                        audioSource.PlayOneShot(fillOxygenTankClip);
                    }
                }
            }
        }
    }
}
