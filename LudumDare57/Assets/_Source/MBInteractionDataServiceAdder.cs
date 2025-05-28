using DecoyInventorySystem;
using InteractionSystem;
using OxygenTankSystem;
using UnityEngine;

public class MBInteractionDataServiceAdder : MonoBehaviour
{
    [SerializeField] private MBInteractionData interactionData;

    [Header("Interaction Services")]
    [SerializeField] private AudioSource interactionAudioSource;
    [SerializeField] private MBOxygenTank oxygenTank;
    [SerializeField] private MBDecoyInventory decoyInventory;

    private void Start()
    {
        interactionData.TryAddService(interactionAudioSource);
        interactionData.TryAddService(oxygenTank as IOxygenTank);
        interactionData.TryAddService(decoyInventory as IDecoyInventory);
    }
}
