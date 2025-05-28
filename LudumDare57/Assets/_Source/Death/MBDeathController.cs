using GameSystem.GameLoss;
using OxygenConsumerSystem;
using UnityEngine;

namespace DeathSystem
{
    public class MBDeathController : MonoBehaviour
    {
        [SerializeField] private MBOxygenConsumer oxygenConsumer;
        [SerializeField] private GameLossController gameLossController;

        private void Start()
        {
            oxygenConsumer.OnSuffocationStarted += Die;
        }

        private void Die()
        {
            gameLossController.LoseGame();

            gameObject.SetActive(false);
        }
    }
}
