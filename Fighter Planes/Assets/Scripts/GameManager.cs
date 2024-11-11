using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyOne;
    public GameObject cloud;
    public GameObject coinPrefab;   // Reference to the Coin prefab
    public AudioClip coinPickupSound;  // Reference to the coin pick-up sound
    public TextMeshProUGUI scoreText;   // Reference to the score UI

    private int score;
    private CoinSpawner coinSpawner;  // Reference to the CoinSpawner

    void Start()
    {
        // Initialize player
        Instantiate(player, transform.position, Quaternion.identity);

        // Initialize the score
        score = 0;
        scoreText.text = "Score: " + score;

        // Start creating enemies
        InvokeRepeating("CreateEnemyOne", 1f, 3f);

        // Create sky
        CreateSky();

        // Initialize CoinSpawner
        coinSpawner = gameObject.AddComponent<CoinSpawner>();  // Add CoinSpawner to the GameManager
        coinSpawner.coinPrefab = coinPrefab;  // Set the coin prefab
        coinSpawner.coinPickupSound = coinPickupSound;  // Set the coin pick-up sound
        coinSpawner.StartCoinSpawning();  // Start coin spawning
    }

    void Update()
    {
        // Update logic for game loop (optional)
    }

    void CreateEnemyOne()
    {
        // Create enemies at random positions
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        // Create clouds in the background
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }
}
