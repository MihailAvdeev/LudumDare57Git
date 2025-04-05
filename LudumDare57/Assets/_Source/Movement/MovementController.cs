using UnityEngine;

namespace MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;

        private Rigidbody2D _rigidbody;

        private Vector2 _targetVelocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_targetVelocity == Vector2.zero)
            {
                if (_rigidbody.velocity != Vector2.zero)
                {
                    _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, Vector2.zero, _deceleration * Time.deltaTime);
                }
            }
            else
            {
                if (_rigidbody.velocity != _targetVelocity)
                {
                    _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, _targetVelocity, _acceleration * Time.deltaTime);
                }
            }
        }

        public void Move(Vector2 direction)
        {
            _targetVelocity = direction * _maxSpeed;
        }
    }
}
