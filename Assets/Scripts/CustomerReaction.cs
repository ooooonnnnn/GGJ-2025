using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerReaction : MonoBehaviour
{
    public GameManager gameManager;
    public int position;
    public float waitTime;
    private float timer = 0;

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            Leave();
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
        gameManager.RemoveSatisfiedCustomer(position);
    }
}
