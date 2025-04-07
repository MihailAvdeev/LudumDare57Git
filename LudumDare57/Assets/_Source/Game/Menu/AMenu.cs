using UnityEngine;

namespace GameSystem
{
    public abstract class AMenu : MonoBehaviour
    {
        public void OpenMenu()
        {
            OnMenuOpened();

            gameObject.SetActive(true);
        }

        public void CloseMenu()
        {
            OnMenuclosed();

            gameObject.SetActive(false);
        }

        protected abstract void OnMenuOpened();

        protected abstract void OnMenuclosed();
    }
}
