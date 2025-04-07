using UnityEngine;
using Pathfinding;
using System;

namespace EnemySystem
{
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float movementAcceleration;
        [Space]
        [SerializeField] private float rotationSpeed;
        [Space]
        [SerializeField] private float nextWaypointDistance;

        // TODO: solve the jiggling problem
        // [SerializeField] private Transform visuals;

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
                Vector2 targetDirection = ((Vector2)_path.vectorPath[_currentWaypoint] - _rigidbody.position).normalized;

                float targetRotation = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                _rigidbody.rotation = Mathf.MoveTowardsAngle(_rigidbody.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                Vector2 targetVelocity = targetDirection * movementSpeed;
                _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, targetVelocity, movementSpeed * Time.deltaTime);

                float distance = Vector2.Distance(_rigidbody.position, _path.vectorPath[_currentWaypoint]);
                if (distance < nextWaypointDistance)
                {
                    _currentWaypoint++;
                }

                // TODO: solve the jiggling problem
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
