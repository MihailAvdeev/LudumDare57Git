using CustomUtilities;
using FlashlightInputSystem;
using FlashlightSystem;
using InteractionInputSystem;
using InteractionSystem;
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

        [Header("Interaction")]
        [SerializeField] private InteractionFinder interactionFinder;
        [SerializeField] private AudioSource interactionAudioSource;

        private void Start()
        {
            PlayerControls playerControls = new();

            InteractionData interactionData = new();
            interactionData.TryAddService(interactionAudioSource);
            InteractionController interactionController = new(interactionFinder, interactionData);
            InteractionInputListener interactionInputListener = new(playerControls.Interaction, interactionController);

            MovementInputListener movementInputListener = new(playerControls.Movement, movementController, lookController);

            FlashlightController flashlightController = new(flashlightView);
            FlashlightInputListener flashlightInputListener = new(playerControls.Flashlight, flashlightController);

            OxygenTank oxygenTank = new(100)
            {
                OxygenAmount = 100
            };
            OxygenConsumer oxygenConsumer = new(0.25f, oxygenTank, coroutineManager);
            OxygenTankUIController oxygenTankUIController = new(oxygenTankUIView);
            oxygenTankUIController.DisplayOxygenTank(oxygenTank);
            interactionData.TryAddService(oxygenTank);

            playerControls.Movement.Enable();
            playerControls.Flashlight.Enable();
            playerControls.Interaction.Enable();
        }
    }
}
