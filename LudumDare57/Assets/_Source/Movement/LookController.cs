using UnityEngine;

namespace MovementSystem
{
    public class LookController : MonoBehaviour
    {
        [SerializeField] private float turningSpeed;
        [SerializeField] private bool turnInstantly;

        private Vector3 _target;

        private void Update()
        {
            Vector3 direction = (_target - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;

            transform.eulerAngles = new(0f, 0f, angle);
        }

        public void LookAt(Vector2 mousePosition)
        {
            _target = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
