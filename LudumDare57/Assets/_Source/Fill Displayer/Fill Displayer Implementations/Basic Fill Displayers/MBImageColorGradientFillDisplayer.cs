using UnityEngine;
using UnityEngine.UI;

namespace FillDisplayerSystem
{
    public class MBImageColorGradientFillDisplayer : AMBColorGradientFillDisplayer
    {
        [SerializeField] private Image image;

        protected override void DisplayColor(Color color)
        {
            image.color = color;
        }
    }
}