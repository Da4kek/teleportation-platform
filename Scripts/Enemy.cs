using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    public GameObject bloodsplash;

    public float distance = 2f;
    public float speed;
    public bool moveRight = true;
    public Transform GroundDetection;


    int currentHealth;
    public int maxHealth = 100;
    //public Animator EnemyDied;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //EnemyDied.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {

            Die();
        }

    }
    
    void Die()
    {
        Debug.Log("enemy died");
        //EnemyDied.SetBool("IsDead" , true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        this.enabled = false;
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(bloodsplash, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position,Vector2.down , distance);
        if (groundInfo.collider == false)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }


}
