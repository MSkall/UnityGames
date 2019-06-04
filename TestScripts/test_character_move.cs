using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_character_move : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotation = 0.0f;
    public float FOVangle = 110.0f;
    public float distance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // movement
        if (Input.GetKey(KeyCode.W)) //foward
        {
            //Debug.Log("W key");
            transform.position += (Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) // backward
        {
            //Debug.Log("S key");
            transform.position += (-Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            //Debug.Log("A key");
            transform.position += (-Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            // Debug.Log("D key");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // shooting
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.T))
        {
            Shoot();
        }

        // detection
        // in theory is happening based on entering collision/trigger
        // would then have access to the other gameobject
        if (Input.GetKeyDown(KeyCode.F))
        {
            FOVDetection();
        }
    }

    public void Shoot()
    {
        // ray cast
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Debug.Log("hit.transform.gameObject.name: " + hit.transform.gameObject.name);
            GameObject other = hit.transform.gameObject;
            DetectInRadius(other);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    public void FOVDetection()
    {
        //Vector3 dir = other.transform.position - transform.position; // other - player gives vector from player to other
        //float angle = Vector3.Angle(dir, transform.forward);

        //if (angle < (FOVangle / 2))
        //{
        //    RaycastHit hit;

        //    // Does the ray intersect any objects excluding the player layer
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        //    {
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //        Debug.Log("Did Hit");
        //        Debug.Log("hit.transform.gameObject.name: " + hit.transform.gameObject.name);
        //    }
        //    else
        //    {
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //        Debug.Log("Did not Hit");
        //    }
        //}
    }

    public void DetectInRadius(GameObject other)
    {
        if(Vector3.Distance(transform.position, other.transform.position) < distance)
        {
            Debug.Log("Object is within the radius");
        }
        else 
        {
            Debug.Log("Object is NOT within the radius");
        }
    }
}
