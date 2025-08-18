using UnityEngine;

public class TPtoHOME : MonoBehaviour
{
    public Vector3 startPos = new Vector3(-21.22f, -7.91f, 0f);
    public void IfEntrytheBlock(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = startPos; // Teleport player to the start position
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IfEntrytheBlock(other); // Call the method to handle respawn
    }
}
