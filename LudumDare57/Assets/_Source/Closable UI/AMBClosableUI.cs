using UnityEngine;

namespace ClosableUISystem
{
    public abstract class AMBClosableUI : MonoBehaviour, IClosableUI
    {
        public abstract void Open();
        public abstract void Close();
    }
}
