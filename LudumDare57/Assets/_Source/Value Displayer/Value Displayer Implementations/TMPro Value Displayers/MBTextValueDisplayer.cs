using System;
using TMPro;
using UnityEngine;

namespace ValueDisplayerSystem
{
    public class MBTextValueDisplayer : AMBValueDisplayer
    {
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private string textBeforeValue;
        [SerializeField] private string textAfterValue;
        [SerializeField] private int fractionalPartDigits;

        public override void DisplayValue(float value)
        {
            string text = textBeforeValue;

            if (value > 1000000000.0f || value < -1000000000.0f)
            {
                text += $"{MathF.Round(value / 1000000000.0f, fractionalPartDigits, MidpointRounding.ToEven)}B"; ;
            }
            else if (value > 1000000.0f || value < -1000000.0f)
            {
                text += $"{MathF.Round(value / 1000000.0f, fractionalPartDigits, MidpointRounding.ToEven)}M";
            }
            else if (value > 1000.0f || value < -1000.0f)
            {
                text += $"{MathF.Round(value / 1000.0f, fractionalPartDigits, MidpointRounding.ToEven)}K";
            }
            else
            {
                text += $"{MathF.Round(value, fractionalPartDigits, MidpointRounding.ToEven)}";
            }

            text += textAfterValue;

            valueText.text = text;
        }
    }
}
