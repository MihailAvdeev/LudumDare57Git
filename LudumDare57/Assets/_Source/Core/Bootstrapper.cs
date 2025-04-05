using FlashlightInputSystem;
using FlashlightSystem;
using MovementInputSystem;
using MovementSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private LookController lookController;

        [Space]
        [SerializeField] private FlashlightView flashlightView;

        private void Start()
        {
            PlayerControls playerControls = new();

            MovementInputListener movementInputListener = new(playerControls.Movement, movementController, lookController);

            FlashlightController flashlightController = new(flashlightView);
            FlashlightInputListener flashlightInputListener = new(playerControls.Flashlight, flashlightController);

            playerControls.Movement.Enable();
            playerControls.Flashlight.Enable();
        }
    }
}
