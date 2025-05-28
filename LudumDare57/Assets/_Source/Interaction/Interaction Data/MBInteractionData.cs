using UnityEngine;

namespace InteractionSystem
{
    public class MBInteractionData : MonoBehaviour, IInteractionData
    {
        private InteractionData _interactionData;

        private InteractionData InteractionData
        {
            get
            {
                _interactionData ??= new();

                return _interactionData;
            }
        }

        public bool TryAddService<T>(T service)
        {
            return InteractionData.TryAddService(service);
        }

        public bool TryGetService<T>(out T service)
        {
            return InteractionData.TryGetService(out service);
        }

        public bool TryRemoveService<T>()
        {
            return InteractionData.TryRemoveService<T>();
        }
    }
}
