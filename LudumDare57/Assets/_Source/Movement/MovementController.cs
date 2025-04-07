using UnityEngine;

namespace MovementSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;
        [SerializeField] private Transform torso;
        [SerializeField] private Transform body;
        [SerializeField] private Animator animator;

        private Rigidbody2D _rigidbody;

        private Vector2 _targetVelocity;
        private float _targetAngle;

        private int _animatorSwimmingHash;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animatorSwimmingHash = Animator.StringToHash("IsSwimming");
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
                float angle = Mathf.MoveTowardsAngle(body.eulerAngles.z, _targetAngle, 200.0f * Time.deltaTime);
                body.eulerAngles = new(0f, 0f, angle);

                if (_rigidbody.velocity != _targetVelocity)
                {
                    _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, _targetVelocity, _acceleration * Time.deltaTime);
                }
            }
        }

        public void Move(Vector2 direction)
        {
            _targetVelocity = direction * _maxSpeed;
            _targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            if (direction.x < -0.01f)
            {
                torso.localScale = new Vector3(1.0f, -1.0f, 1.0f);
            }
            else if(direction.x > 0.01f)
            {
                torso.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

            if (direction.magnitude > 0f)
            {
                animator.SetBool(_animatorSwimmingHash, true);
            }
            else
            {
                animator.SetBool(_animatorSwimmingHash, false);
            }
        }
    }
}
