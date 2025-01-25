using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    
    void Start()
    {
        foreach (GameObject o in objects)
        {
            if (GameObject.FindWithTag(o.tag) == null)
            {
                Instantiate(o);
            }
        }
    }

}
