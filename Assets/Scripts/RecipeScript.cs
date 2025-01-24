using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecipeScript : MonoBehaviour
{
    // [SerializeField] private int maxNumIngredients;
    [SerializeField] private BubbleGraphics preview;
    private Recipe recipe;
    
    public void SetSize(int size)
    {
        recipe = new Recipe();
        recipe.size = size;
        
        preview.SetRecipe(recipe);
    }

    public void SetColor(int color)
    {
        if (recipe.size == -1)
        {
            return;
        }
        recipe.color = color;
        
        preview.SetRecipe(recipe);
    }

    public void SetSparkles(int sparkles)
    {
        if (recipe.size == -1)
        {
            return;
        }
        recipe.sparkles = sparkles;
        
        preview.SetRecipe(recipe);
    }

    public Recipe OutputRecipe()
    {
        Recipe output = recipe == null ? recipe : new Recipe(recipe);
        recipe = new Recipe();
        preview.SetRecipe(recipe);
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

    public static bool Equal(Recipe thisOne, Recipe otherOne)
    {
        return thisOne.size == otherOne.size &&
               thisOne.color == otherOne.color &&
               thisOne.sparkles == otherOne.sparkles;
    }
}
// -1 means not defined
// 0,1,2 correspond to each specific option