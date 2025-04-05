using MovementInputSystem;
using MovementSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private LookController lookController;

        private void Start()
        {
            PlayerControls playerControls = new();

            MovementInputListener movementInputListener = new(playerControls.Movement, movementController, lookController);

            playerControls.Movement.Enable();
        }
    }
}
