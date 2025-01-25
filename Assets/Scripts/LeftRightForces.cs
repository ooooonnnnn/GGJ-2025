using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LeftRightForces : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float forceDuration;
    // [SerializeField] private float holdTimeThreshold;
    [SerializeField] private float forceStrength;
    [SerializeField] [Range(0f,1f)] private float forceUpRatio;
    public bool controllable = true;
    
    private int currentForceDirection = 0;
    private float forceTimer = 0;
    private bool applyForce;
    // private float keyHoldTimer = 0;

    private void Start()
    {
        //random angular velocity
        rb.AddTorque(Random.Range(-1f,1f) * 2, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            forceTimer = 0;
            // keyHoldTimer = 0;
        }
        
        applyForce = false;
        if (forceTimer < forceDuration)
        {
            if (Input.GetKey(KeyCode.D))
            {
                forceTimer += Time.deltaTime;
                currentForceDirection = 1;
                applyForce = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                forceTimer += Time.deltaTime;
                currentForceDirection = -1;
                applyForce = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (applyForce && controllable)
        {
            rb.AddForce(forceStrength * new Vector2(currentForceDirection, forceUpRatio));
        }
    }
}
