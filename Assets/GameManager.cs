using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;
public class GameManager : MonoBehaviour
{
    public int Coinstospawn = 5; // Maximum number of coins to collect
    public PlayerMovement player; // Reference to the PlayerMovement script
    public static GameManager I;
    public GameObject coinPrefab; // Reference to the Coin prefab
    [Header("UI")]
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text coinsText;

    [Header("Gameplay")]
    [SerializeField] private int maxLives = 3;
    public int Lives { get; set; }
    void Start()
    {
        InitializeGame();
    }
    public void UpdateLivesUI()
    {
            livesText.text = "You have " + Lives + " lifes";
    }
    public void UpdateCoinsUI()
    {
            coinsText.text = "You have to collect " + (5 - player.Count) + " coins to win";
    }
    private void InitializeGame()
    {
        // Initialize any game settings or variables here
        Lives = maxLives;
        UpdateLivesUI();
        UpdateCoinsUI();
        SpawnCoins();
    }
    public void SpawnCoins()
    {
        Vector3[] SpawnPoints = new Vector3[]
        {
            new Vector3(-20.35f, 8.7f, 0f),
            new Vector3(3.94f, 5.69f, 0f),
            new Vector3(17.37f, 4.85f, 0f),
            new Vector3(19.94f, 9f, 0f),
            new Vector3(14.51f, 0.36f, 0f),
            new Vector3(-4.38f, -3.96f, 0f),
            new Vector3(21.19f, -5.99f, 0f),
            new Vector3(-19.3f, -9.33f, 0f),
            new Vector3(19.73f, -3.3f, 0f),
            new Vector3(15.09823f, 2.719216f, 0f)
        };
        int[] indices = new int[SpawnPoints.Length];
        for (int i = 0; i < indices.Length; i++)
            indices[i] = i;
        for (int i = indices.Length - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            int tmp = indices[i];
            indices[i] = indices[rand];
            indices[rand] = tmp;
        }
        for (int i = 0; i < Coinstospawn; i++)
        {
            Vector3 spawnPosition = SpawnPoints[indices[i]];
            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
