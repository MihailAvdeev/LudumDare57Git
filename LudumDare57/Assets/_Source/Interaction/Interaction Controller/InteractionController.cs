using System;
using System.Collections.Generic;

namespace InteractionSystem
{
    public class InteractionController : IInteractionController
    {
        private readonly IInteractionData _interactionData;

        private IInteractable _currentInteractable;

        public InteractionController(MBInteractionFinder interactionFinder, IInteractionData interactionData)
        {
            if (interactionFinder == null) throw new ArgumentNullException(nameof(interactionFinder));
            interactionFinder.OnInteractablesUpdated += UpdateCurrentInteractable;

            _interactionData = interactionData ?? throw new System.ArgumentNullException(nameof(interactionData));
        }

        public void Interact()
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.Interact(_interactionData);
                _currentInteractable = null;
            }
        }

        private void UpdateCurrentInteractable(List<IInteractable> interactables)
        {
            if (interactables.Contains(_currentInteractable))
            {
                return;
            }
            else
            {
                if (_currentInteractable != null)
                {
                    _currentInteractable.HideInteraction();
                    _currentInteractable = null;
                }

                if (interactables.Count > 0)
                {
                    _currentInteractable = interactables[0];
                    _currentInteractable.ShowInteraction();
                }
            }
        }
    }
}