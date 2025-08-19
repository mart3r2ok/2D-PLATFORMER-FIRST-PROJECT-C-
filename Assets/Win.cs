using UnityEngine;

public class Win : MonoBehaviour
{
    public PlayerMovement Player; // Reference to the PlayerMovement script
    public void Winn()
    {
        // Logic to handle winning the game
        Debug.Log("You win!");
        // You can add more logic here, like showing a win screen or transitioning to another scene
        gameObject.SetActive(true);
        Player.gameObject.SetActive(false); // Disable the player object
    }
}
