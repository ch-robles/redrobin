using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    private int attackCounter = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform attackPoint;
    public float attackRange = 0.7f;

    public LayerMask playerLayers;
    public int attackDamage = 20;

    public EnemyController enemyChase;
    public Enemy enemyHealth;

    public PlayerController playerMovement;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime && enemyHealth.GetHealth() > 0)
        {
            if (enemyChase.IsChasing())
            {
                Attack();
                nextAttackTime = Time.time + 1.5f / attackRate;
                attackCounter++;
            }
        }

        if (attackCounter > 3)
        {
            attackCounter = 1;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        animator.SetInteger("Counter", attackCounter);

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (player.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
            if (player.transform.position.x > transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
