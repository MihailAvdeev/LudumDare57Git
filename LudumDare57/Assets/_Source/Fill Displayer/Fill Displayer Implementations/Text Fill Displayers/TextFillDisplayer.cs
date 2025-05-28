using FillDisplayerSystem;
using TMPro;
using UnityEngine;

namespace FillDisplayerImplementations
{
    public class TextFillDisplayer : AMBFillDisplayer
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private string textBeforeNumber;
        [SerializeField] private string textAfterNumber;
        [SerializeField] private float multiplyBy;
        [SerializeField] private bool toInt;

        public override void DisplayFill(float fill)
        {
            fill *= multiplyBy;

            string numberString;

            if (toInt)
                numberString = Mathf.FloorToInt(fill).ToString();
            else
                numberString = fill.ToString();

            text.text = $"{textBeforeNumber}{numberString}{textAfterNumber}";
        }
    }
}