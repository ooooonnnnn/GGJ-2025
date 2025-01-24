using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientScript : MonoBehaviour
{
    [SerializeField] private RecipeScript recipe;
    [SerializeField] private int ingredientNum;
    [SerializeField] private IngredientType type;
    
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
    }
}

public enum IngredientType
{
    Size,
    Color,
    Sparkles
}
