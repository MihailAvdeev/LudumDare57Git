using UnityEngine;

namespace InteractionSystem
{
    public class MBInteractionController : MonoBehaviour, IInteractionController
    {
        [SerializeField] private MBInteractionFinder interactionFinder;
        [SerializeField] private MBInteractionData interactionData;

        private InteractionController _interactionController;

        private InteractionController InteractionController
        {
            get
            {
                _interactionController ??= new(interactionFinder, interactionData);

                return _interactionController;
            }
        }

        private void OnEnable()
        {
            _interactionController ??= new(interactionFinder, interactionData);
        }

        public void Interact()
        {
            InteractionController.Interact();
        }
    }
}
