using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 300;
    public int health;

    public Animator animator;

    public HealthBar healthBar;

    //public UIManager ui;

    [SerializeField] GameObject deathPanel;
    public static bool GameIsPaused = false;
    public GameObject inGameUI;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        audioManager.PlaySFX(audioManager.hurt);

        if (health <= 0)
        {
            Die();
        }

        healthBar.SetHealth(health);
    }

    void Die()
    {
        audioManager.PlaySFX(audioManager.death);
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;

        ToggleDeathPanel();
    }

    public int GetHealth()
    {
        return health;
    }

    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
