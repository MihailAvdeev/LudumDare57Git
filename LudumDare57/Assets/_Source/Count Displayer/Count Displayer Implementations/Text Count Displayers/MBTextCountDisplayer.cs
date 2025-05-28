using CountDisplayerSystem;
using TMPro;
using UnityEngine;

namespace CountDisplayerImplementations
{
    public class MBTextCountDisplayer : AMBCountDisplayer
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private string textBeforeNumber;
        [SerializeField] private string textAfterNumber;

        public override void DisplayCount(int count)
        {
            text.text = $"{textBeforeNumber}{count}{textAfterNumber}";
        }
    }
}