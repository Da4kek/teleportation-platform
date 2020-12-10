using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject hitEffect;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int Damage = 40;
    public LayerMask enemyLayers;
    public float AttackRate = 2f;
    float AttackTime = 0f;

    //public Animator animator;
    void Update()
    {

        if(Time.time >=AttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                AttackTime = Time.time + 1f / AttackRate;
                
            }
        }


        
    }
    void Attack()
    {
        //animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , enemyLayers);
        

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(Damage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
