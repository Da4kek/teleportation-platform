using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    public bool isUp;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && player.GetComponent<PlayerMovement>().isGrounded )
        {
            transform.parent.GetComponent<Collider2D>().enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.parent.GetComponent<Collider2D>().enabled = isUp;
        }
    }

}
