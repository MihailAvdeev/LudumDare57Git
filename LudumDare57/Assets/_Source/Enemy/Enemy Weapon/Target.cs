using System;
using UnityEngine;

namespace EnemySystem
{
    public class Target : MonoBehaviour, ITarget
    {
        public event Action<int> OndamageRecieved;

        public void DealDamage(int damage)
        {
            OndamageRecieved?.Invoke(damage);
        }
    }
}
