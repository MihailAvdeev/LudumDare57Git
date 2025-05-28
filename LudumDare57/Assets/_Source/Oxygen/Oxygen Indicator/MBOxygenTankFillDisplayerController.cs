using FillDisplayerSystem;
using OxygenTankSystem;
using UnityEngine;

namespace OxygenTankUISystem
{
    public class MBOxygenTankFillDisplayerController : MonoBehaviour
    {
        [SerializeField] private MBOxygenTank oxygenTank;
        [SerializeField] private AMBFillDisplayer oxygenTankFillDisplayer;

        private OxygenTankFillDisplayerController _oxygenTankFillDisplayerController;

        private void Start()
        {
            _oxygenTankFillDisplayerController = new(oxygenTankFillDisplayer);

            _oxygenTankFillDisplayerController.DisplayOxygenTank(oxygenTank);
        }
    }
}
