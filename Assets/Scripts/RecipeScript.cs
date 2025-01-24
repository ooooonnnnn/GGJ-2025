using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeScript : MonoBehaviour
{
    [SerializeField] private int maxNumIngredients;
    private Recipe recipe;
    
    public void SetSize(int size)
    {
        recipe = new Recipe();
        recipe.size = size;
    }

    public void SetColor(int color)
    {
        if (recipe == null)
        {
            return;
        }

        recipe.color = color;
    }

    public void SetSparkles(int sparkles)
    {
        if (recipe == null)
        {
            return;
        }

        recipe.sparkles = sparkles;
    }

    public Recipe OutputRecipe()
    {
        Recipe output = new Recipe(recipe);
        recipe = null;
        return output;
    }
// private void Update()
    // {
    //     if (recipe == null)
    //     {
    //         return;
    //     }
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         print($"Size: {recipe.size}, Color: {recipe.color}, Sparkles: {recipe.sparkles}");
    //     }
    // }
    
}

public class Recipe
{
    public int size = -1, color = -1, sparkles = -1;

    public Recipe(Recipe recipe)
    {
        size = recipe.size;
        color = recipe.color;
        sparkles = recipe.sparkles;
    }

    public Recipe(){}
}
