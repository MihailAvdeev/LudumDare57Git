using FillDisplayerSystem;
using UnityEngine;

namespace FillDisplayerImplementations
{
    public class MBCompositeFillDisplayer : AMBFillDisplayer
    {
        [SerializeField] private AMBFillDisplayer[] fillDisplayers = new AMBFillDisplayer[0];

        public override void DisplayFill(float fill)
        {
            foreach (var fillDisplayer in fillDisplayers)
                fillDisplayer.DisplayFill(fill);
        }
    }
}