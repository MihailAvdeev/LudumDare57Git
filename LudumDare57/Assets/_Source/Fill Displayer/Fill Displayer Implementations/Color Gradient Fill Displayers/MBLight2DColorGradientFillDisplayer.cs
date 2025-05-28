using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FillDisplayerImplementations
{
    public class MBLight2DColorGradientFillDisplayer : AMBColorGradientFillDisplayer
    {
        [SerializeField] private Light2D light2D;

        protected override void DisplayColor(Color color)
        {
            light2D.color = color;
        }
    }
}