using UnityEngine;
using Pathfinding;
using System;

namespace MonsterMovementSystem
{
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(Rigidbody2D))]
    public class MonsterMovement : MonoBehaviour
    {
        [SerializeField] private float quiteMovementSpeed;
        [SerializeField] private float agressiveMovementSpeed;
        [SerializeField] private float movementAcceleration;
        [Space]
        [SerializeField] private float rotationSpeed;
        [Space]
        [SerializeField] private float nextWaypointDistance;

        [SerializeField] private Transform visuals;

        private Path _path;
        private int _nextWaypointIndex = 0;

        private Seeker _seeker;
        private Rigidbody2D _rigidbody;

        private float _actualSpeed;

        public bool ReachedEndOfPath { get; private set; } = false;

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

            if (_nextWaypointIndex >= _path.vectorPath.Count)
            {
                ReachedEndOfPath = true;

                OnEndOfPathReached?.Invoke();
            }
            else
            {
                ReachedEndOfPath = false;
            }

            if (!ReachedEndOfPath)
            {
                Vector2 targetDirection = ((Vector2)_path.vectorPath[_nextWaypointIndex] - _rigidbody.position).normalized;
                
                float targetRotation = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                _rigidbody.rotation = Mathf.MoveTowardsAngle(_rigidbody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                
                Vector2 targetVelocity = targetDirection * _actualSpeed;
                _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, targetVelocity, movementAcceleration * Time.deltaTime);

                float distance = Vector2.Distance(_rigidbody.position, _path.vectorPath[_nextWaypointIndex]);
                if (distance < nextWaypointDistance)
                    _nextWaypointIndex++;

                if (targetDirection.x >= 0.5f)
                {
                    visuals.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
                else if (targetDirection.x <= -0.5f)
                {
                    visuals.localScale = new Vector3(1.0f, -1.0f, 1.0f);
                }
            }
        }

        public void MoveToPosition(Vector3 position)
        {
            if (_seeker.IsDone())
                _seeker.StartPath(_rigidbody.position, position, OnPathComplete);
        }

        public void StopMoving()
        {
            _actualSpeed = 0.0f;
        }

        public void SetAgressiveSpeed()
        {
            _actualSpeed = agressiveMovementSpeed;
        }

        public void SetQuiteSpeed()
        {
            _actualSpeed = quiteMovementSpeed;
        }

        private void OnPathComplete(Path path)
        {
            if (!path.error)
            {
                _path = path;
                _nextWaypointIndex = 1;
            }
        }
    }
}
