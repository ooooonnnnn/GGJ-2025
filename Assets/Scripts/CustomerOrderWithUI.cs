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

    // Booleans for Sparkles options
    public bool hasSparkles = false;

    // UI element to display the order
    [Header("Order components")] 
    [SerializeField] private SpriteRenderer ticketSprite;
    [SerializeField] private SpriteRenderer colorSprite;
    [SerializeField] private SpriteRenderer sparkleSprite;
    [SerializeField] private Sprite[] tickets;
    [SerializeField] private Color[] colorDashes;
    [SerializeField] private Sprite[] sparkleSprites;

    // Recipe will be saved as Recipe class (Defined in RecipeScript)
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        recipe = new Recipe();

        // Generate the customer's order
        GenerateOrder();

        // Update the UI with the generated order
        UpdateOrderUI();
    }

    // Function to generate the customer's order
    private void GenerateOrder()
    {
        // Randomly decide whether the customer has a shampoo or glitter
        hasShampoo = Random.value > 0.5f; // 50% chance to order shampoo
        hasSparkles = Random.value > 0.5f; // 50% chance to order sparkles

        // If the customer orders shampoo, randomly pick a color
        if (hasShampoo)
        {
            int shampooChoice = Random.Range(0, 3);

            recipe.color = shampooChoice;
        }

        // If the customer orders sparkles, randomly pick a type
        if (hasSparkles)
        {
            int sparklesChoice = Random.Range(0, 3);

            recipe.sparkles = sparklesChoice;
        }

        // Size is mandatory, randomly pick one size (Small, Medium, Large)
        int sizeChoice = Random.Range(0, 3);
        recipe.size = sizeChoice;
    }

    // // Function to return the customer's order as a string (for UI display)
    // string GenerateOrderString()
    // {
    //     string order = "Customer Order: ";
    //
    //     // Add shampoo to the order string if available
    //     if (hasShampoo)
    //     {
    //         if (shampooPurple) order += "Purple Shampoo ";
    //         else if (shampooBlue) order += "Blue Shampoo ";
    //         else if (shampooPink) order += "Pink Shampoo ";
    //     }
    //
    //     // Add glitter to the order string if available
    //     if (hasSparkles)
    //     {
    //         if (sparklesStars) order += "with Star sparkles ";
    //         else if (sparklesMoon) order += "with Moon sparkles ";
    //         else if (sparklesBanana) order += "with Banana sparkles ";
    //     }
    //
    //     // Add size to the order string (mandatory)
    //     if (sizeSmall) order += "Size: Small";
    //     else if (sizeMedium) order += "Size: Medium";
    //     else if (sizeLarge) order += "Size: Large";
    //
    //     return order.Trim();
    // }

    // Function to update the UI with the customer's order
    void UpdateOrderUI()
    {
        // Size
        ticketSprite.sprite = tickets[recipe.size];
        
        // Color
        colorSprite.color = recipe.color == -1 ? new Color(0,0,0,0) : colorDashes[recipe.color];

        //Sparkl 
        sparkleSprite.sprite = recipe.sparkles == -1 ? null : sparkleSprites[recipe.sparkles];
    }
}