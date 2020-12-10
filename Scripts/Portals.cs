using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    private Transform destination;
    public float distance;
    public bool isGreen;

    void Start()
    {
        if(isGreen == true)
        {
            destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("GreenPortal").GetComponent<Transform>();
        }

    }
    
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(Vector2.Distance(transform.position,collision.transform.position) > distance)
        {
            collision.transform.position = new Vector2(destination.position.x, destination.position.y);
        }


        
    }


}
