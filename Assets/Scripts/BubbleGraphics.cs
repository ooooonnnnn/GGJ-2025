using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGraphics : MonoBehaviour
{
    public Recipe recipe;
    [SerializeField] private SpriteRenderer color, sparkles;
    [SerializeField] private float[] sizes;
    [SerializeField] private Sprite[] colorSprites;
    [SerializeField] private Sprite[] sparkleSprites;
    [SerializeField] private Sprite defaultColor, defaultSparkles;
    public void SetRecipe(Recipe recipe)
    {
        this.recipe = new Recipe(recipe);
        color.sprite = recipe.color == -1 ? defaultColor : colorSprites[recipe.color];
        sparkles.sprite = recipe.sparkles == -1 ? defaultSparkles : sparkleSprites[recipe.sparkles];
        transform.localScale = new Vector3(1f, 1f, 1f) * sizes[recipe.size];
    }
}
