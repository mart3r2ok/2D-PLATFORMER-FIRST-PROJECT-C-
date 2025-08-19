using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public PlayerMovement player; // Reference to the PlayerMovement script
    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void IfTouch(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.Count++; // Increment the player's item count
            gameManager.UpdateCoinsUI(); // Update the UI to reflect the new coin count
            Destroy(gameObject); // Destroy the money object after taking it
            player.WinLogic();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IfTouch(other); // Call the method to handle item collection
    }
}
