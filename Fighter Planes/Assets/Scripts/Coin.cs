using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner spawner;
    private AudioClip pickupSound;
    private AudioSource audioSource;

    public void Initialize(CoinSpawner spawner, float lifetime)
    {
        this.spawner = spawner;
        audioSource = gameObject.AddComponent<AudioSource>();  

       
        gameObject.SetActive(false);
        Debug.Log("Coin Initialized and set to inactive.");

       
        Destroy(gameObject, lifetime);
    }

    
    public void ActivateCoin()
    {
        gameObject.SetActive(true);  
        Debug.Log("Coin activated and is now visible.");
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.name);

       
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin picked up by player!");

            
            spawner?.AddScore(1);

            
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
                Debug.Log("Played pickup sound.");
            }

            
            Destroy(gameObject);
            Debug.Log("Coin destroyed after pickup.");
        }
    }
}
