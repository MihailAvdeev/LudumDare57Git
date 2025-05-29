using UnityEngine;

namespace ClosableUISystem
{
    public class MBCombinedClosableUI : AMBClosableUI
    {
        [SerializeField] private AMBClosableUI[] closableUIs = new AMBClosableUI[0];

        public override void Open()
        {
            foreach (var closableUI in closableUIs)
            {
                closableUI.Open();
            }
        }

        public override void Close()
        {
            foreach (var closableUI in closableUIs)
            {
                closableUI.Close();
            }
        }
    }
}
