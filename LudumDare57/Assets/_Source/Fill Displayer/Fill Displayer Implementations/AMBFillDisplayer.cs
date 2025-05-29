using UnityEngine;

namespace FillDisplayerSystem
{
    public abstract class AMBFillDisplayer : MonoBehaviour, IFillDisplayer
    {
        public abstract void DisplayFill(float fill);
    }
}
