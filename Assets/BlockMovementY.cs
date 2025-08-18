using UnityEngine;

public class BlockMovementY : MonoBehaviour
{
    public float speed = 1.7f; // Speed of the block movement
    public Vector3 topPoint; // Top boundary
    public Vector3 bottomPoint; // Bottom boundary
    public bool isMovingUp = true; // Direction of movement
    void Start()
    {
        bottomPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.72f, gameObject.transform.position.z); // Set bottom boundary
        topPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.72f, gameObject.transform.position.z); // Set top boundary
    }
    void Update()
    {
        Vector3 targetPosition = isMovingUp ? topPoint : bottomPoint; // Determine target position based on direction
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime); // Move block towards target position
        isMovingUp = Vector3.Distance(gameObject.transform.position, targetPosition) >= 0.01f ? isMovingUp : !isMovingUp; // Reverse direction if close to target position
    }
}
