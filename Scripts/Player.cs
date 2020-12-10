using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public Rigidbody2D rb;
    public int currentHealth;
    public HealthBar healthbar; 
    public int knockbackduration =100;
    
    
    

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
      if(currentHealth <=0)
        {
            FindObjectOfType<GameManager>().EndGame();
            
            
        }
      if(rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

       

    }
    public void Damage(int damage)
    {
        currentHealth -= damage;
        Vector2 ExternelForce = new Vector2(-50f, 50f);
        rb.AddForce(ExternelForce);
    }

    public IEnumerator Knockback(float knockdur ,float knockbackpwr , Vector3 knockbackdir)
    {
        float timer = 0f;

        while(knockdur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackdir.x * knockbackduration, knockbackdir.y * knockbackpwr,transform.position.z));
        }
        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            TakeDamage(20);
        }
    }

}
