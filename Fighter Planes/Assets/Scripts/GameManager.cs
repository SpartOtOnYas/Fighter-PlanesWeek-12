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
    public GameObject coinPrefab;   
    public AudioClip coinPickupSound;  
    public TextMeshProUGUI scoreText;   
    public TextMeshProUGUI livesText;
    private Player playerScript;

    private int score;
    private CoinSpawner coinSpawner;


    void Start()
    {
        
        player = Instantiate(player, transform.position, Quaternion.identity);

        playerScript = player.GetComponent<Player>();
        Debug.Log(playerScript.lives);

        
        score = 0;
        scoreText.text = "Score: " + score;

        
        InvokeRepeating("CreateEnemyOne", 1f, 3f);

        
        CreateSky();

        
        coinSpawner = gameObject.AddComponent<CoinSpawner>();  
        coinSpawner.coinPrefab = coinPrefab; 
        coinSpawner.coinPickupSound = coinPickupSound;  
        coinSpawner.StartCoinSpawning();

        
    }

    void Update()
    {
        if(player !=null){
            livesText.text = "Lives: " + playerScript.lives;
        }
        else if (player == null)
        {
            livesText.text = "Lives: 0";
        }
        
    }

    void CreateEnemyOne()
    {
       
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        
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
