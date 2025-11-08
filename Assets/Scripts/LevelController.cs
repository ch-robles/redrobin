using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject winUI;
    public GameObject inGameUI;
    public static bool GameIsPaused = false;

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
        if(other.tag == "Player" && KeyCounter.keyAmount == 1)
        {
            winUI.SetActive(true);
            inGameUI.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
            audioManager.PlaySFX(audioManager.win);
        }
    }
}
