using UnityEngine;
using Pathfinding;
using System.Collections;

namespace EnemySystem
{
    [RequireComponent(typeof(Seeker)), RequireComponent(typeof(Rigidbody2D))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform player;

        [SerializeField] private float speed;
        [SerializeField] private float nextWaypointDistance;

        [SerializeField] private float pathUpdateTime;

        [SerializeField] private Transform visuals;

        private Path _path;
        private int _currentWaypoint = 0;
        private bool _reachedEndOfPath = false;

        private Seeker _seeker;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _seeker = GetComponent<Seeker>();
            _rigidbody = GetComponent<Rigidbody2D>();

            StartCoroutine(UpdatingPath());
        }

        private void Update()
        {
            if (_path == null)
                return;

            if (_currentWaypoint >= _path.vectorPath.Count)
            {
                _reachedEndOfPath = true;
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
                _rigidbody.rotation = Mathf.MoveTowardsAngle(_rigidbody.rotation, targetRotation, 100.0f * Time.deltaTime);

                _rigidbody.AddForce(force);

                float distance = Vector2.Distance(_rigidbody.position, _path.vectorPath[_currentWaypoint]);

                if (distance < nextWaypointDistance)
                {
                    _currentWaypoint++;
                }
                
                if (force.x >= 0.01f)
                {
                    visuals.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
                else if (force.x <= -0.01f)
                {
                    visuals.localScale = new Vector3(1.0f, -1.0f, 1.0f);
                }
            }
        }

        private void OnPathComplete(Path path)
        {
            if (!path.error)
            {
                _path = path;
                _currentWaypoint = 0;
            }
        }

        private IEnumerator UpdatingPath()
        {
            WaitForSeconds wait = new(pathUpdateTime);

            while (true)
            {
                if (_seeker.IsDone())
                {
                    _seeker.StartPath(_rigidbody.position, player.position, OnPathComplete);
                }

                yield return wait;
            }
        }
    }
}
