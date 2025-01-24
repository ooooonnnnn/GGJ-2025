using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomerOrderWithUI : MonoBehaviour
{
    // Booleans for Shampoo options
    public bool hasShampoo = false;
    public bool shampooPurple = false;
    public bool shampooBlue = false;
    public bool shampooPink = false;

    // Booleans for Sparkles options
    public bool hasSparkles = false;
    public bool sparklesStars = false;
    public bool sparklesMoon = false;
    public bool sparklesBanana = false;

    // Booleans for Size options (Small, Medium, Large)
    public bool sizeSmall = false;
    public bool sizeMedium = false;
    public bool sizeLarge = false;

    // UI element to display the order
    [Header("Order components")]
    public TMP_Text orderText;
    public TMP_Text sizeText;
    // Color
    public TextMeshProUGUI redColorIcon;
    public TextMeshProUGUI blueColorIcon;
    public TextMeshProUGUI pinkColorIcon;
    // Sparkles
    public TextMeshProUGUI starSparkleIcon;
    public TextMeshProUGUI moonSparkleIcon;
    public TextMeshProUGUI bananaSparkleIcon;

    // Recipe will be saved as Recipe class (Defined in RecipeScript)
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
    redColorIcon.enabled = false;
    blueColorIcon.enabled = false;
    pinkColorIcon.enabled = false;
    starSparkleIcon.enabled = false;
    moonSparkleIcon.enabled = false;
    bananaSparkleIcon.enabled = false;

        recipe = new Recipe();
        // Check if orderText is assigned
        if (orderText == null)
        {
            Debug.LogWarning("OrderText is not assigned in the Inspector.");
            return;
        }

        // Generate the customer's order
        GenerateOrder();

        // Update the UI with the generated order
        UpdateOrderUI();
    }

    // Function to generate the customer's order
    void GenerateOrder()
    {
        // Randomly decide whether the customer has a shampoo or glitter
        hasShampoo = Random.value > 0.5f; // 50% chance to order shampoo
        hasSparkles = Random.value > 0.5f; // 50% chance to order sparkles

        // If the customer orders shampoo, randomly pick a color
        if (hasShampoo)
        {
            int shampooChoice = Random.Range(0, 3);
            if (shampooChoice == 0) shampooPurple = true;
            else if (shampooChoice == 1) shampooBlue = true;
            else if (shampooChoice == 2) shampooPink = true;

            recipe.color = shampooChoice;
        }

        // If the customer orders sparkles, randomly pick a type
        if (hasSparkles)
        {
            int sparklesChoice = Random.Range(0, 3);
            if (sparklesChoice == 0) sparklesStars = true;
            else if (sparklesChoice == 1) sparklesMoon = true;
            else if (sparklesChoice == 2) sparklesBanana = true;

            recipe.sparkles = sparklesChoice;
        }

        // Size is mandatory, randomly pick one size (Small, Medium, Large)
        int sizeChoice = Random.Range(0, 3);
        if (sizeChoice == 0) sizeSmall = true;
        else if (sizeChoice == 1) sizeMedium = true;
        else if (sizeChoice == 2) sizeLarge = true;
        recipe.size = sizeChoice;
    }

    // Function to return the customer's order as a string (for UI display)
    string GenerateOrderString()
    {
        string order = "Customer Order: ";

        // Add shampoo to the order string if available
        if (hasShampoo)
        {
            if (shampooPurple) order += "Purple Shampoo ";
            else if (shampooBlue) order += "Blue Shampoo ";
            else if (shampooPink) order += "Pink Shampoo ";
        }

        // Add glitter to the order string if available
        if (hasSparkles)
        {
            if (sparklesStars) order += "with Star sparkles ";
            else if (sparklesMoon) order += "with Moon sparkles ";
            else if (sparklesBanana) order += "with Banana sparkles ";
        }

        // Add size to the order string (mandatory)
        if (sizeSmall) order += "Size: Small";
        else if (sizeMedium) order += "Size: Medium";
        else if (sizeLarge) order += "Size: Large";

        return order.Trim();
    }

    // Function to update the UI with the customer's order
    void UpdateOrderUI()
    {
        // Generate the order string and update the Text UI
        string orderString = GenerateOrderString();
        // Size
        switch(recipe.size){
            case 0:
            sizeText.text = "S";
            break;
            case 1:
            sizeText.text = "M";
            break;
            case 2:
            sizeText.text = "L";
            break;
        }
        
        // Color
        switch(recipe.color){
            case 0:
            redColorIcon.enabled = true;
            Debug.Log("Here");
            break;
            case 1:
            blueColorIcon.enabled = true;
            Debug.Log("Here");
            break;
            case 2:
            pinkColorIcon.enabled = true;
            Debug.Log("Here");
            break;
        }

        //Sparkl 
        switch(recipe.sparkles){
            case 0:
            starSparkleIcon.enabled = true;
            break;
            case 1:
            moonSparkleIcon.enabled = true;
            break;
            case 2:
            bananaSparkleIcon.enabled = true;
            break;
        }
    }
}