using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemySystem
{
    public class PercievedObject : MonoBehaviour
    {
        public float Distance;
        public bool IsHidden;

        public float ActualDistance { get { return IsHidden ? Distance - hiddenEffect : Distance; } }

        [SerializeField] private LayerMask percievingLayers;
        [SerializeField] private int priority;
        [SerializeField] private float hiddenEffect;

        private HashSet<IPerciever> _currentPercievers = new();

        private void FixedUpdate()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ActualDistance, percievingLayers);
            HashSet<IPerciever> percievers = new();

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out IPerciever perciever))
                {
                    percievers.Add(perciever);

                    if (!_currentPercievers.Contains(perciever))
                    {
                        perciever.StartPercieving(this);
                    }
                }
            }

            foreach (IPerciever perciever in _currentPercievers.ToArray())
            {
                if (!percievers.Contains(perciever))
                {
                    perciever.StopPercieving(this);
                    _currentPercievers.Remove(perciever);
                }
            }

            _currentPercievers.UnionWith(percievers);
        }
    }
}
