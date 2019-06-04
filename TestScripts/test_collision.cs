using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collision : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("other.gameObject.name");
        Debug.Log("other.gameObject.name: " + other.gameObject.name);
        if (other.gameObject.name == "Character")
        {
            Debug.Log("collided with chicken!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            Debug.Log("no longer colliding with chicken");
        }
    }


}
