using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    private Player player;

    
    public float knockbackforce = -70f;
    public float knockbacktime = 0.2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            
            StartCoroutine(player.Knockback(knockbacktime, knockbackforce,player.transform.position));
        }
    }

}
