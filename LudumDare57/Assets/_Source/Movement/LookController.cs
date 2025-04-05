using UnityEngine;

namespace MovementSystem
{
    public class LookController : MonoBehaviour
    {
        public void LookAt(Vector2 mousePosition)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = (target - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            transform.eulerAngles = new(0f, 0f, angle);
        }
    }
}
