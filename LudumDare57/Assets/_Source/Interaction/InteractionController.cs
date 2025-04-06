using System.Collections.Generic;

namespace InteractionSystem
{
    public class InteractionController
    {
        private InteractionFinder _interactionFinder;
        private InteractionData _interactionData;

        private IInteractable _currentInteractable;

        public InteractionController(InteractionFinder interactionFinder, InteractionData interaction)
        {
            _interactionFinder = interactionFinder ?? throw new System.ArgumentNullException(nameof(interactionFinder));
            _interactionData = interaction ?? throw new System.ArgumentNullException(nameof(interaction));

            _interactionFinder.OnInteractablesUpdated += UpdateCurrentInteractable;
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