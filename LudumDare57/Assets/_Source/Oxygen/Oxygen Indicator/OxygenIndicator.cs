using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace OxygenSystem
{
    public class OxygenIndicator : MonoBehaviour
    {
        [SerializeField] private Image oxygenBarFill;
        [SerializeField] private Gradient oxygenBarGradient;
        [SerializeField] private Light2D oxygenTankLight;
        [SerializeField] private Gradient oxygenLightGradient;

        public void DisplayOxygenTankFill(float fill)
        {
            oxygenBarFill.fillAmount = fill;
            oxygenBarFill.color = oxygenBarGradient.Evaluate(fill);
            oxygenTankLight.color = oxygenLightGradient.Evaluate(fill);
        }
    }
}
