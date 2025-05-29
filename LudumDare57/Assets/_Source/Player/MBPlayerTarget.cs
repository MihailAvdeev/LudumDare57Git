using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

namespace PlayerSystem
{
    public class MBPlayerTarget : MonoBehaviour, ITarget
    {
        [SerializeField] private AudioSource effectsAudioSource;
        [SerializeField] private AudioClip deathAudioClip;

        public UnityEvent OnDeath;

        public void RecieveDamage(int damage)
        {
            Die();
        }

        private void Die()
        {
            effectsAudioSource.PlayOneShot(deathAudioClip);

            OnDeath?.Invoke();
        }
    }
}
