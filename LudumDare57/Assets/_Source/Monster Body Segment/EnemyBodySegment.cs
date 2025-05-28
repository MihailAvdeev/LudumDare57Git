using UnityEngine;

public class EnemyBodySegment : MonoBehaviour
{
    [SerializeField] private Transform previousSegment;

    [SerializeField] private float distance = 3.0f;
    [SerializeField] private float moveStep = 10.0f;

    private void Update()
    {
        Vector3 direction = (previousSegment.position - transform.position).normalized;

        Vector3 targetPosition = previousSegment.position - direction * distance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveStep * Time.deltaTime);

        float targetRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new(0f, 0f, targetRotation);

        if (direction.x >= 0.01f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (direction.x <= -0.01f)
        {
            transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
        }
    }
}
