using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiasManager : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DiasCounter.diasAmount += 1;
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.collect);
        }
    }
}
