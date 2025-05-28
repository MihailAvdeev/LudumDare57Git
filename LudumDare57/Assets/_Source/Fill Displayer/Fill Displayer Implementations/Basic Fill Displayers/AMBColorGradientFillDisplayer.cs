using FillDisplayerSystem;
using UnityEngine;

namespace FillDisplayerImplementations
{
    public abstract class AMBColorGradientFillDisplayer : AMBFillDisplayer
    {
        [SerializeField] private Gradient colorGradient;

        public override void DisplayFill(float fill)
        {
            DisplayColor(colorGradient.Evaluate(fill));
        }

        protected abstract void DisplayColor(Color color);
    }
}