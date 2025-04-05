using CustomUtilities;
using FlashlightInputSystem;
using FlashlightSystem;
using MovementInputSystem;
using MovementSystem;
using OxygenSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private LookController lookController;

        [Space]
        [SerializeField] private FlashlightView flashlightView;

        [Header("Oxygen")]
        [SerializeField] private OxygenTankUIView oxygenTankUIView;

        [Space]
        [SerializeField] private CoroutineManager coroutineManager;

        private void Start()
        {
            PlayerControls playerControls = new();

            MovementInputListener movementInputListener = new(playerControls.Movement, movementController, lookController);

            FlashlightController flashlightController = new(flashlightView);
            FlashlightInputListener flashlightInputListener = new(playerControls.Flashlight, flashlightController);

            OxygenTank oxygenTank = new(100);
            oxygenTank.OxygenAmount = 100;
            OxygenConsumer oxygenConsumer = new(0.25f, oxygenTank, coroutineManager);
            OxygenTankUIController oxygenTankUIController = new(oxygenTankUIView);
            oxygenTankUIController.DisplayOxygenTank(oxygenTank);

            playerControls.Movement.Enable();
            playerControls.Flashlight.Enable();
        }
    }
}
