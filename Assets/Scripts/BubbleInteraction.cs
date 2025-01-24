using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleInteraction : MonoBehaviour
{
    [SerializeField] private BubbleGraphics graphics;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] popClips;
    [SerializeField] private GameObject graphicsGO;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject customerGO = other.gameObject;
        CustomerOrderWithUI order = customerGO.GetComponent<CustomerOrderWithUI>();
        
        // print($"my recipe: {graphics.recipe.size}, {graphics.recipe.color}, {graphics.recipe.sparkles}\n" +
        //       $"his recipe: {customer.recipe.size}, {customer.recipe.color}, {customer.recipe.sparkles}");
        if (Recipe.Equal(order.recipe, graphics.recipe))
        {
            customerGO.GetComponent<CustomerReaction>().Satisfied();
        }
        
        //play pop sound
        print("pop");
        AudioClip clip = popClips[Random.Range(0, popClips.Length)];
        audioSource.pitch = math.exp(Random.Range(-0.2f, 0.2f));
        audioSource.PlayOneShot(clip);
        Destroy(graphicsGO);
        Destroy(gameObject,3f);
    }
}
