using System;
using UnityEngine;
using UnityEngine.UI;

namespace ValueDisplayerSystem
{
    public class MBSpriteSwapValueDisplayer : AMBValueDisplayer
    {
        [SerializeField] private Image swapedImage;

        [Space]
        [SerializeField] private SwapSpriteAndValue[] swapSpriteAndValues = new SwapSpriteAndValue[0];

        public override void DisplayValue(float value)
        {
            if (swapSpriteAndValues.Length == 0)
                return;

            Sprite sprite = swapSpriteAndValues[0].Sprite;

            foreach (SwapSpriteAndValue v in swapSpriteAndValues)
            {
                if (value >= v.Value)
                {
                    sprite = v.Sprite;
                }
            }

            swapedImage.sprite = sprite;
        }

        [Serializable]
        private struct SwapSpriteAndValue
        {
            [field: SerializeField] public float Value { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
        }
    }
}
