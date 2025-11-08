using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManagerVer2 : MonoBehaviour
{
    public GameObject door;

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
        if (other.tag == "Player")
        {
            KeyCounter.keyAmount += 1;
            Destroy(gameObject);
            door.GetComponent<BoxCollider2D>().isTrigger = true;
            audioManager.PlaySFX(audioManager.collect);
        }
    }
}