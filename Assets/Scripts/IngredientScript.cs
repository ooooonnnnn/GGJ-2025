using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class IngredientScript : MonoBehaviour
{
    [SerializeField] private RecipeScript recipe;
    [SerializeField] private int ingredientNum;
    [SerializeField] private IngredientType type;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    
    private void OnMouseDown()
    {
        switch (type)
        {
            case IngredientType.Size:
                recipe.SetSize(ingredientNum);
                break;
            case IngredientType.Color:
                recipe.SetColor(ingredientNum);
                break;
            case IngredientType.Sparkles:
                recipe.SetSparkles(ingredientNum);
                break;
        }

        if (clip != null)
        {
            audioSource.pitch = math.exp(Random.Range(-0.2f, 0.2f));
            audioSource.PlayOneShot(clip);
        }
    }
}

public enum IngredientType
{
    Size,
    Color,
    Sparkles
}
