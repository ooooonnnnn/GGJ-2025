using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerReaction : MonoBehaviour
{
    public GameManager gameManager;
    public int position;
    
    public void Satisfied()
    {
        //tell the game manager
        print("Thanks!!!!!");
        gameManager.RemoveSatisfiedCustomer(position);
    }
}
