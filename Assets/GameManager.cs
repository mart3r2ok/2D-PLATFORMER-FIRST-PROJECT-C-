using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;
public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [Header("UI")]
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text coinsText;

    [Header("Gameplay")]
    [SerializeField] private int maxLives = 3;
    public int Lives { get; set; }
    public int Coins { get; set; } = 0;
    public int CoinsTotal { get; private set; } = 5;
    void Start()
    {
        if (I == null)
        {
            I = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeGame();
    }
    public void UpdateLivesUI()
    {
            livesText.text = "You have " + Lives + " lifes";
    }
    public void UpdateCoinsUI()
    {
            coinsText.text = "You have to collect " + (CoinsTotal - Coins) + " coins to win";
    }
    private void InitializeGame()
    {
        // Initialize any game settings or variables here
        Lives = maxLives;
        Coins = 0;
        UpdateLivesUI();
        UpdateCoinsUI();
    }
}
