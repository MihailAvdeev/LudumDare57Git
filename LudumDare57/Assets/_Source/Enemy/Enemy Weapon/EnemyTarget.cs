using UnityEngine;

namespace EnemySystem
{
    public class EnemyTarget : MonoBehaviour
    {
        public void DealDamage(int damage)
        {
            Debug.Log($"Recieved damage {damage}");
        }
    }
}
