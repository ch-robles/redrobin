using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionManager : MonoBehaviour
{
    public Player player;

    public int healthBonus = 50;

    public HealthBar healthBar;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.health < player.maxHealth)
            {
                player.health = player.health + healthBonus;
                healthBar.SetHealth(player.health);
            }
            HealthPotionCounter.potionAmount += 1;
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.collect);
        }
    }
}
