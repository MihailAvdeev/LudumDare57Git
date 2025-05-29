using PerceptionSystem;
using UnityEngine;
using ValueDisplayerSystem;

namespace PerceptionUISystem
{
    public class MBVisibilityDisplayer : MonoBehaviour
    {
        [SerializeField] private APercievedObject percievedObject;

        [SerializeField] private AMBValueDisplayer valueDisplayer;

        private void Update()
        {
            valueDisplayer.DisplayValue(percievedObject.Visibility);
        }
    }
}
