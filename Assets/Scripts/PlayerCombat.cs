using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private int attackCounter = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform attackPoint;
    public float attackRange = 0.7f;

    public LayerMask enemyLayers;
    public int attackDamage = 20;

    public Player playerHealth;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime && playerHealth.GetHealth() > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.O))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                attackCounter++;
            }
        }

        if (attackCounter > 4)
        {
            attackCounter = 1;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        animator.SetInteger("Counter", attackCounter);
        audioManager.PlaySFX(audioManager.attack);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().KBCounter = enemy.GetComponent<EnemyController>().KBTotalTime;
            if (enemy.transform.position.x <= transform.position.x)
            {
                enemy.GetComponent<EnemyController>().KnockFromRight = true;
            }
            if (enemy.transform.position.x > transform.position.x)
            {
                enemy.GetComponent<EnemyController>().KnockFromRight = false;
            }
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
