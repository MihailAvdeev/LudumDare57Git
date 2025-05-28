using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

namespace PlayerSystem
{
    public class PlayerTarget : MonoBehaviour, ITarget
    {
        public UnityEvent OnDamageRecieved;

        public void RecieveDamage(int damage)
        {
            Die();
        }

        private void Die()
        {
            Debug.Log("I die");

            OnDamageRecieved.Invoke();
        }
    }
}
