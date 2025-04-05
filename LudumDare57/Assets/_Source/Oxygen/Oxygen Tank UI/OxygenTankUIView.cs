using UnityEngine;
using UnityEngine.UI;

namespace OxygenSystem
{
    public class OxygenTankUIView : MonoBehaviour
    {
        [SerializeField] private Image oxygenBarFill;
        [SerializeField] private Gradient oxygenAmountGradient;

        public void DisplayOxygenTankFill(float fill)
        {
            oxygenBarFill.fillAmount = fill;
            oxygenBarFill.color = oxygenAmountGradient.Evaluate(fill);
        }
    }
}
