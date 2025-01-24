using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGraphics : MonoBehaviour
{
    public Recipe recipe;

    public void SetRecipe(Recipe recipe)
    {
        this.recipe = new Recipe(recipe);
    }
}
