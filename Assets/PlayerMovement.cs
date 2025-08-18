using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float hp = 3; // Player's health points
    public float timer = 0f;
    public float fix = 0.5f;
    public float prev; // Previous position of the player
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 5f; // Force applied when jumping
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded = true; // Check if the player is on the ground
    public LayerMask groundLayer; // Layer for the ground
    public Transform groundCheck; // Transform to check if the player is grounded
    public float groundCheckRadius = 0.2f; // Radius for the ground check
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        prev = gameObject.transform.position.y; // Initialize previous position
    }
    void Update()
    {
        timer += Time.deltaTime; // Increment timer
        float now = gameObject.transform.position.y;
        Jump(); // Call the Jump method to handle jumping
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }
        /* if(gameObject.transform.position.y <= -9.559f || gameObject.transform.position.y >= 9.833f)
        {
            Debug.Log("Player went off the platform");
            gameObject.transform.position = new Vector3(-20.817f, -7.949f, 0f);
        }
        */
        if (timer >= 0.5f)
        {
            timer = 0f; // Reset timer after logging
            if (!isGrounded && Mathf.Abs(prev - now) < 0.01f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - fix, 0);
            }
                prev = now; // Update previous position
        }
    }
    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
