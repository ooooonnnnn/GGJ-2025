using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    [SerializeField] private BubbleGraphics graphics;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject customerGO = other.gameObject;
        CustomerOrderWithUI order = customerGO.GetComponent<CustomerOrderWithUI>();
        
        // print($"my recipe: {graphics.recipe.size}, {graphics.recipe.color}, {graphics.recipe.sparkles}\n" +
        //       $"his recipe: {customer.recipe.size}, {customer.recipe.color}, {customer.recipe.sparkles}");
        if (Recipe.Equal(order.recipe, graphics.recipe))
        {
            customerGO.GetComponent<CustomerInteraction>().Satisfied();
        }
        
        //play pop sound
        print("pop");
        Destroy(this.gameObject);
    }
}
