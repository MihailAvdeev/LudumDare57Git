using UnityEngine;

namespace EnemySystem
{
    [RequireComponent(typeof(Collider2D))]
    public class Cover : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out PercievedObject percievedObject))
            {
                percievedObject.IsHidden = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out PercievedObject percievedObject))
            {
                percievedObject.IsHidden = false;
            }
        }
    }
}
