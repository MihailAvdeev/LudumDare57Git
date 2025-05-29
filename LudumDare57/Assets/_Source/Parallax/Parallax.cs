using UnityEngine;

namespace ParallaxSystem
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [Space]
        [SerializeField] private float horizontalParallax;
        [SerializeField] private float verticalParallax;

        private Vector2 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void FixedUpdate()
        {
            float distanceX = (cameraTransform.position.x - _startPosition.x) * horizontalParallax;
            float distanceY = (cameraTransform.position.y - _startPosition.y) * verticalParallax;
            transform.position = new Vector3(_startPosition.x + distanceX, _startPosition.y + distanceY, transform.position.z);
        }
    }
}