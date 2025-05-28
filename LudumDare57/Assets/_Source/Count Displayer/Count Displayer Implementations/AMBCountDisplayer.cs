using UnityEngine;

namespace CountDisplayerSystem
{
    public abstract class AMBCountDisplayer : MonoBehaviour, ICountDisplayer
    {
        public abstract void DisplayCount(int count);
    }
}
