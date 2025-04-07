using UnityEngine;
using Pathfinding;
using System;

namespace EnemySystem
{
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float nextWaypointDistance;

        [SerializeField] private Transform visuals;

        private Path _path;
        private int _currentWaypoint = 0;
        private bool _reachedEndOfPath = false;

        private Seeker _seeker;
        private Rigidbody2D _rigidbody;

        public event Action OnEndOfPathReached;

        private void Awake()
        {
            _seeker = GetComponent<Seeker>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_path == null)
                return;

            if (_currentWaypoint >= _path.vectorPath.Count)
            {
                _reachedEndOfPath = true;

                OnEndOfPathReached?.Invoke();
            }
            else
            {
                _reachedEndOfPath = false;
            }

            if (!_reachedEndOfPath)
            {
                Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rigidbody.position).normalized;
                Vector2 force = direction * (speed * Time.deltaTime);

                float targetRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                float actualRotation = Mathf.MoveTowardsAngle(visuals.eulerAngles.z, targetRotation, 100.0f * Time.deltaTime);
                visuals.eulerAngles = new Vector3(0f, 0f, actualRotation);

                _rigidbody.AddForce(force);

                float distance = Vector2.Distance(_rigidbody.position, _path.vectorPath[_currentWaypoint]);

                if (distance < nextWaypointDistance)
                {
                    _currentWaypoint++;
                }
                /*
                if (direction.x >= 0.5f)
                {
                    visuals.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
                else if (direction.x <= -0.5f)
                {
                    visuals.localScale = new Vector3(1.0f, -1.0f, 1.0f);
                }*/
            }
        }

        public void MoveToPosition(Vector3 position)
        {
            if (_seeker.IsDone())
                _seeker.StartPath(_rigidbody.position, position, OnPathComplete);
        }

        private void OnPathComplete(Path path)
        {
            if (!path.error)
            {
                _path = path;
                _currentWaypoint = 0;
            }
        }
    }
}
