using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    public GameObject Player; // Reference to the PlayerMovement script
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Player.gameObject.SetActive(true);
    }
}
