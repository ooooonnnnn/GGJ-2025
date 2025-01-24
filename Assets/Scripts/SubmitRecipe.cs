using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SubmitRecipe : MonoBehaviour
{
    [SerializeField] private Transform spawner;
    [SerializeField] private RecipeScript recipe;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private float[] initAngleRange;
    [SerializeField] private float[] initSpeedRange;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void OnMouseDown()
    {
        if (GenerateBubble())
        {
            print("blub");
            audioSource.pitch = math.exp(Random.Range(-0.2f, 0.2f));
            audioSource.PlayOneShot(clip);
        }
    }

    private GameObject newBubble = null;
    private bool GenerateBubble()
    {
        Recipe recipeForBubble = recipe.OutputRecipe();
        if (recipeForBubble.size == -1)
        {
            return false;
        }

        if (newBubble != null)
        {
            newBubble.GetComponent<LeftRightForces>().controllable = false;
        }
        
        newBubble = Instantiate(bubblePrefab, spawner);
        newBubble.GetComponent<BubbleGraphics>().SetRecipe(recipeForBubble);

        float angle = Random.Range(initAngleRange[0], initAngleRange[1]);
        float speed = Random.Range(initSpeedRange[0], initSpeedRange[1]);
        Vector2 velocity = speed * new Vector2(math.cos(angle), math.sin(angle));
        
        newBubble.GetComponent<Rigidbody2D>().AddForce(velocity,ForceMode2D.Impulse);

        return true;
    }
}
