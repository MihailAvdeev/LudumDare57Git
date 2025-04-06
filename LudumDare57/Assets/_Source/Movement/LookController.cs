using UnityEngine;

namespace MovementSystem
{
    public class LookController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float xThreshold;
        [SerializeField] private float yThreshold;
        [SerializeField] private Transform aimTarget;
        [SerializeField] private Transform body;

        public float AimDistance { get; set; }

        public void LookAt(Vector2 mouseScreenPosition)
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = 0f;
            Vector3 direction = (mouseWorldPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            transform.eulerAngles = new(0f, 0f, angle);

            aimTarget.localPosition = direction * AimDistance;

            if (direction.y < -0.01f)
            {
                body.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else if (direction.y > 0.01f)
            {
                body.localScale = new Vector3(1.0f, -1.0f, 1.0f);
            }
        }
    }
}
