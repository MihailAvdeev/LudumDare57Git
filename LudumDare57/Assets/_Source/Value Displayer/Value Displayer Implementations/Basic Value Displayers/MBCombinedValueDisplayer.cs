using UnityEngine;

namespace ValueDisplayerSystem
{
    public class MBCombinedValueDisplayer : AMBValueDisplayer
    {
        [SerializeField] private AMBValueDisplayer[] valueDisplayers = new AMBValueDisplayer[0];

        public override void DisplayValue(float value)
        {
            foreach (var valueDisplayer in valueDisplayers)
            {
                valueDisplayer.DisplayValue(value);
            }
        }
    }
}
