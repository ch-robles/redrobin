using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public GameObject door;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && KeyCounter.keyAmount == 1)
        {
            animator.SetBool("isOpen", true);
            door.GetComponent<BoxCollider2D>().enabled = false;
            audioManager.PlaySFX(audioManager.door);
        }
    }
}
