using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(-20.817f, -7.949f, 0f); // Default respawn position
    public Transform player; // Reference to the player object
    public PlayerMovement playermove;
    public GAMEOVERLOGIC gameoverlogic; // Reference to the game over logic script
    public void ifEntrytheBlock(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawnPosition; // Move player to respawn position
            --playermove.hp;
            gameoverlogic.Check(); // Call the check method to handle player health
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ifEntrytheBlock(other); // Call the method to handle respawn
    }
}
