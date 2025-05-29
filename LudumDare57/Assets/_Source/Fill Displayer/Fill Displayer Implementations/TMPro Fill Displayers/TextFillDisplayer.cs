using TMPro;
using UnityEngine;

namespace FillDisplayerSystem
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
            if (fill < 0.0f)
                fill = 0.0f;

            if (fill > 1.0f)
                fill = 1.0f;

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