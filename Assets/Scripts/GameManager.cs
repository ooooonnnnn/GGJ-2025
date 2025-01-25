using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    // List of spawn points in the map
    public Transform[] spawnPoints;

    // Prefab for the customer
    public GameObject customerPrefab;

    [SerializeField] private TMP_Text livesText;
    [FormerlySerializedAs("startingLife")] [SerializeField] private int startingLives;
    private int currentLives;
    
    // Customer wait time starts at 12 seconds and decreases every 7 seconds
    public float customerWaitTime = 12f;

    // Spawn interval starts at 8 seconds and increases every 7 seconds
    public float spawnInterval = 8f;

    // Game time counter (in seconds, updated every frame)
    public float gameTime = 0f;
    [SerializeField] private float levelDuration;
    [SerializeField] private ScoreData scoreData;

    // Internal counter to track when to apply the 7-second adjustment rule
    private float timeSinceLastAdjustment = 0f;

    // Track active customers and their spawn points
    private Dictionary<int, GameObject> activeCustomers = new Dictionary<int, GameObject>();

    // Counters for customer tracking
    public int leftBeforeCompletion = 0; // Customers who left before order completion
    public int leftAfterCompletion = 0;  // Customers who left after order completion
    public int totalCustomers = 0;       // Total number of customers who appeared in the restaurant

    public int diffcultyChangeTime = 30; // The time changed the diffcilty 
    

    private void Start()
    {
        // Start the coroutine responsible for spawning customers
        StartCoroutine(SpawnCustomers());
        currentLives = startingLives;
        UpdateLives();
    }

    private void UpdateLives()
    {
        livesText.text = $"Lives: {currentLives}";
        if (currentLives <= 0)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        scoreData = GameObject.FindWithTag("Score Data").GetComponent<ScoreData>();
        scoreData.timeLeftOnStage = levelDuration - gameTime;
        SceneManager.LoadScene("End Screen");
    }

    private void Update()
    {
        // Update game time
        gameTime += Time.deltaTime;
        if (gameTime >= levelDuration)
        {
            EndLevel();
        }

        // Update the time since the last adjustment
        timeSinceLastAdjustment += Time.deltaTime;

        // Every 7 seconds, adjust spawn interval and customer wait time
        if (timeSinceLastAdjustment >= diffcultyChangeTime)
        {
            AdjustSpawnAndWaitTimes();
            timeSinceLastAdjustment = 0f; // Reset the adjustment timer
        }
    }

    private IEnumerator SpawnCustomers()
    {
        while (true)
        {
            // Try to spawn a customer at a free spawn point
            SpawnCustomer();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnCustomer()
    {
        // Find a free spawn point
        int freeSpawnPoint = GetFreeSpawnPoint();

        if (freeSpawnPoint != -1)
        {
            // Increment the total customers counter
            totalCustomers++;

            // Instantiate a new customer at the free spawn point
            GameObject newCustomer = Instantiate(customerPrefab, spawnPoints[freeSpawnPoint]);
            CustomerReaction newCustomerReaction = newCustomer.GetComponent<CustomerReaction>();
            newCustomerReaction.gameManager = this;
            newCustomerReaction.position =  freeSpawnPoint;
            newCustomerReaction.waitTime = customerWaitTime;

            // Add the customer to the active customers dictionary
            activeCustomers[freeSpawnPoint] = newCustomer;

            // Start a coroutine to remove the customer after a certain wait time
            // StartCoroutine(RemoveCustomerAfterTime(newCustomer, freeSpawnPoint));
        }
        else
        {
            Debug.Log("No free spawn points available.");
        }
    }

    private int GetFreeSpawnPoint()
    {
        // Loop through all spawn points and return the first free one
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!activeCustomers.ContainsKey(i))
            {
                return i; // Found a free spawn point
            }
        }
        return -1; // No free spawn points
    }

    public void RemoveCustomerAfterTime(GameObject customer, int spawnPoint)
    {

        // Check if the customer is still present
        if (customer != null)
        {
            leftBeforeCompletion++; // Increment the counter for customers who left before order completion
            // Debug.Log("Customer left before completing the order.");

            // Destroy the customer object
            Destroy(customer);

            currentLives = currentLives > 0 ? currentLives - 1 : 0;
            UpdateLives();
        }

        // Remove the spawn point from the active customers dictionary
        if (activeCustomers.ContainsKey(spawnPoint))
        {
            activeCustomers.Remove(spawnPoint);
        }
    }

    public void RemoveSatisfiedCustomer(int key)
    {
        // List<string> s = new List<string>();
        // foreach (KeyValuePair<Transform,GameObject> activeCustomer in activeCustomers)
        // {
        //     s.Add($"key: {activeCustomer.Key.name} value: {activeCustomer.Value.name}\n");
        // }
        // print(string.Join("",s));
        
        Destroy(activeCustomers[key]);
        activeCustomers.Remove(key);
        leftAfterCompletion++;
        
    }

    private void AdjustSpawnAndWaitTimes()
    {
        // Decrease customer wait time by 2 seconds (minimum 1 seconds)
        customerWaitTime = Mathf.Max(2f, customerWaitTime - 1f);

        // Decrease spawn interval by 5 seconds
        spawnInterval -= 0.5f;

        // Debug.Log($"Adjusted Times - Spawn Interval: {spawnInterval}, Customer Wait Time: {customerWaitTime}");
    }
}