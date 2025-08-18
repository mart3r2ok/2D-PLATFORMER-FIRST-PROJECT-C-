using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class BlockMovementX : MonoBehaviour
{
    public float speed = 7f; // Speed of the block movement
    public Vector3 leftPoint; // Left boundary
    public Vector3 rightBound; // Right boundary
    private bool isMovingRight = true; // Direction of movement
    void Start()
    {
        leftPoint = new Vector3(gameObject.transform.position.x - 2f, gameObject.transform.position.y, gameObject.transform.position.z); // Set left boundary
        rightBound = new Vector3(gameObject.transform.position.x + 4f, gameObject.transform.position.y, gameObject.transform.position.z); // Set right boundary
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = isMovingRight ? rightBound : leftPoint; // Determine target position based on direction
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime); // Move block towards target position
        if(Vector3.Distance(gameObject.transform.position, targetPosition) < 0.01f) // Check if block is close to target position
        {
            isMovingRight = !isMovingRight; // Reverse direction
        }
    }
}
