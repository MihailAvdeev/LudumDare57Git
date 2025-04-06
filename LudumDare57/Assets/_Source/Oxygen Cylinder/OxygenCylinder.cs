using InteractionSystem;
using OxygenSystem;
using UnityEngine;
using UnityEngine.Events;

namespace OxygenCylinderSystem
{
    public class OxygenCylinder : MonoBehaviour, IInteractable
    {
        [SerializeField] private AudioClip fillOxygenTankClip;

        [Space]
        [SerializeField] private UnityEvent OnInteractionShown;
        [SerializeField] private UnityEvent OnInteractionHidden;

        public void ShowInteraction()
        {
            OnInteractionShown?.Invoke();
        }

        public void HideInteraction()
        {
            OnInteractionHidden?.Invoke();
        }

        public void Interact(InteractionData interactionData)
        {
            if (interactionData.TryGetService(out OxygenTank oxygenTank))
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
