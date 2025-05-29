using UnityEngine;

namespace ValueDisplayerSystem
{
    public abstract class AMBValueDisplayer : MonoBehaviour, IValueDisplayer
    {
        public abstract void DisplayValue(float value);
    }
}
