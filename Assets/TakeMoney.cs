using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager script
    public PlayerMovement player; // Reference to the PlayerMovement script
    public Win Win1; // Reference to the WinLogic script
    public void IfTouch(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
                player.Count++; // Increment the player's item count
            gameManager.Coins++; // Increment the coins in the GameManager
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
