using UnityEngine;

public class GAMEOVERLOGIC : MonoBehaviour
{
    public GameObject Panel;
    public PlayerMovement Player; 
    public void Check()
    {
        if(Player.hp <= 0)
        {
            PlayerDied();
        }
    }
    void PlayerDied()
    {
        Player.gameObject.SetActive(false); // Disable the player object
        Panel.SetActive(true);
    }
}
