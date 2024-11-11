using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;     // Reference to the Coin prefab
    public float spawnInterval = 2f;  // Time interval to spawn coins
    public float destroyDelay = 3f;   // How long the coin stays on screen before being destroyed
    public AudioClip coinPickupSound; // Coin pickup sound

    // Make this method public so it can be accessed from GameManager
    public void StartCoinSpawning()
    {
        // Start spawning coins at intervals
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        // Calculate a random spawn position within screen bounds (adjust these values as needed)
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-4f, 4f);

        // Spawn the coin at the random position
        GameObject coin = Instantiate(coinPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);

        // Initialize the coin with the spawn parameters (lifetime and pickup sound)
        Coin coinScript = coin.GetComponent<Coin>();
        coinScript.Initialize(this, destroyDelay, coinPickupSound);

        // Activate the coin after instantiation
        coinScript.ActivateCoin();  // Activate the coin (make it visible)

        // Destroy the coin after the set delay
        Destroy(coin, destroyDelay);
    }

    public void AddScore(int score)
    {
        // This method is called when a coin is collected to update the score
        GameManager gameManager = FindObjectOfType<GameManager>();  // Find the GameManager instance
        gameManager.EarnScore(score);  // Call EarnScore from the GameManager to update the score
    }
}