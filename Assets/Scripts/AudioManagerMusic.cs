using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMusic : MonoBehaviour
{
    [Header("------Audio Source-------")]
    [SerializeField] AudioSource musicSource;

    [Header("------Audio Clips-------")]
    public AudioClip background;

    private static AudioManagerMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
