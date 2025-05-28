using FillDisplayerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace FillDisplayerSystem
{
    public class MBSliderFillDisplayer : AMBFillDisplayer
    {
        [SerializeField] private Slider slider;

        public override void DisplayFill(float fill)
        {
            slider.value = fill;
        }
    }
}