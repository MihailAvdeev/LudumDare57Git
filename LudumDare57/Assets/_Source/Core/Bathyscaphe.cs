using InteractionSystem;
using System;
using UnityEngine;

namespace Core
{
    public class Bathyscaphe : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _interactionIndicator;

        public event Action OnBathyscapheEntered;

        public void ShowInteraction()
        {
            _interactionIndicator.SetActive(true);
        }

        public void HideInteraction()
        {
            _interactionIndicator.SetActive(false);
        }

        public void Interact(InteractionData interactionData)
        {
            OnBathyscapheEntered?.Invoke();
        }
    }
}
