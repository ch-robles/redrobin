using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject hit = other.gameObject;

        if (hit.CompareTag("Player"))
        {
            player.TakeDamage(50);
        }
    }
}
