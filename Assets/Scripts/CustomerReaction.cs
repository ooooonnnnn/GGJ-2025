using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerReaction : MonoBehaviour
{
    public GameManager gameManager;
    public int position;
    public float waitTime;
    [SerializeField] private float lingerTime;
    private float waitTimer = 0;
    private float lingerTimer = 0;
    private bool lingering = false;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] dirtySprites;
    [SerializeField] private Sprite[] cleanSprites;
    private int characterType = -1;

    public void Start()
    {
        //choose a random plushy sprite
        characterType = Random.Range(0, dirtySprites.Length);
        spriteRenderer.sprite = dirtySprites[characterType];
    }

    public void Update()
    {
        waitTimer += Time.deltaTime;
        if (waitTimer >= waitTime)
        {
            Leave();
        }

        if (lingering)
        {
            lingerTimer += Time.deltaTime;
            if (lingerTimer >= lingerTime)
            {
                gameManager.RemoveSatisfiedCustomer(position);
            }
        }
    }

    private void Leave()
    {
        gameManager.RemoveCustomerAfterTime(gameObject, position);
    } 
    
    public void Satisfied()
    {
        //tell the game manager
        print("Thanks!!!!!");
        lingering = true;
        spriteRenderer.sprite = cleanSprites[characterType];
    }
}
