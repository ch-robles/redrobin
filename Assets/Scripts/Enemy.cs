using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    public Animator animator;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Die();
        }

        healthBar.SetHealth(health);
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }

    public int GetHealth()
    {
        return health;
    }

}
