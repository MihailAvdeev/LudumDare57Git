using System.Collections;
using UnityEngine;
using WeaponSystem;

namespace DecoySystem
{
    public class Decoy : MonoBehaviour, ITarget
    {
        [SerializeField] private float functioningPeriod;
        [SerializeField] private DecoyPercievedObject percievedObject;

        public void RecieveDamage(int damage)
        {
            Die();
        }

        public void Engage()
        {
            StartCoroutine(Functioning());
        }

        private IEnumerator Functioning()
        {
            percievedObject.IsPercievable = true;

            yield return new WaitForSeconds(functioningPeriod);

            Die();
        }

        private void Die()
        {
            percievedObject.IsPercievable = false;
            Destroy(this.gameObject);
        }
    }
}