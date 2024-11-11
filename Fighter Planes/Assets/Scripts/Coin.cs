using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner spawner;        // Reference to the CoinSpawner script
    private AudioClip pickupSound;      // Sound for coin pickup
    private AudioSource audioSource;    // Audio source for playing sounds

    public void Initialize(CoinSpawner spawner, float lifetime, AudioClip pickupSound)
    {
        this.spawner = spawner;
        this.pickupSound = pickupSound;
        audioSource = gameObject.AddComponent<AudioSource>();  // Add audio source component

        // Initially disable the coin when it's spawned
        gameObject.SetActive(false);  // Set the coin to inactive initially
        Debug.Log("Coin Initialized and set to inactive.");

        // Destroy this coin after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    // Call this to activate the coin and make it visible
    public void ActivateCoin()
    {
        gameObject.SetActive(true);  // Make the coin active (visible) on the screen
        Debug.Log("Coin activated and is now visible.");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.name);  // Log the object that's colliding

        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin picked up by player!");

            // Add score if the spawner is available
            spawner?.AddScore(1);  // Call AddScore on CoinSpawner

            // Play pickup sound
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
                Debug.Log("Played pickup sound.");
            }

            // Destroy the coin immediately after collection
            Destroy(gameObject);
            Debug.Log("Coin destroyed after pickup.");
        }
    }
}
