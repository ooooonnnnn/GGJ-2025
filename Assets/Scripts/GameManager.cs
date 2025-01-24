using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // List of spawn points in the map
    public Transform[] spawnPoints;

    // Prefab for the customer
    public GameObject customerPrefab;

    // Maximum wait time for a customer before disappearing (in seconds)
    public float customerWaitTime = 30f;

    // Dictionary to track active customers and their spawn points
    private Dictionary<Transform, GameObject> activeCustomers = new Dictionary<Transform, GameObject>();

    // Time interval between spawning new customers (in seconds)
    public float spawnInterval = 5f;

    private void Start()
    {
        // Start the coroutine responsible for spawning customers
        StartCoroutine(SpawnCustomers());
    }

    private IEnumerator SpawnCustomers()
    {
        while (true)
        {
            // Try to spawn a customer at a free spawn point
            SpawnCustomer();
            // Wait before attempting the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnCustomer()
    {
        // Find a free spawn point
        Transform freeSpawnPoint = GetFreeSpawnPoint();

        if (freeSpawnPoint != null)
        {
            // Instantiate a new customer at the free spawn point
            GameObject newCustomer = Instantiate(customerPrefab, freeSpawnPoint.position, Quaternion.identity);

            // Add the customer to the active customers dictionary
            activeCustomers[freeSpawnPoint] = newCustomer;

            // Start a coroutine to remove the customer after a certain wait time
            StartCoroutine(RemoveCustomerAfterTime(newCustomer, freeSpawnPoint));
        }
        else
        {
            Debug.Log("No free spawn points available.");
        }
    }

    private Transform GetFreeSpawnPoint()
    {
        // Loop through all spawn points and return the first free one
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (!activeCustomers.ContainsKey(spawnPoint))
            {
                return spawnPoint; // Found a free spawn point
            }
        }
        return null; // No free spawn points
    }

    private IEnumerator RemoveCustomerAfterTime(GameObject customer, Transform spawnPoint)
    {
        // Wait for the specified customer wait time
        yield return new WaitForSeconds(customerWaitTime);

        // If the customer still exists, destroy it
        if (customer != null)
        {
            Destroy(customer);
        }

        // Remove the spawn point from the active customers dictionary
        if (activeCustomers.ContainsKey(spawnPoint))
        {
            activeCustomers.Remove(spawnPoint);
        }
    }
}