using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemySystem
{
    public class PercievedObject : MonoBehaviour, ICoverable
    {
        [SerializeField] private LayerMask percievingLayers;
        [SerializeField] private int priority;
        [SerializeField] private float hiddenEffect;

        public float Distance;

        private readonly HashSet<Cover> _covers = new();
        private bool _isInCover { get { return _covers.Count > 0; } }
        public float ActualDistance { get { return _isInCover ? Distance - hiddenEffect : Distance; } }

        private readonly HashSet<IPerciever> _currentPercievers = new();

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

        public void TakeCover(Cover cover)
        {
            _covers.Add(cover);
        }

        public void LeaveCover(Cover cover)
        {
            _covers.Remove(cover);
        }
    }
}
