using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSFX : MonoBehaviour
{
    [Header("------Audio Source-------")]
    [SerializeField] AudioSource SFXSource;

    [Header("------Audio Clips-------")]
    public AudioClip death;
    public AudioClip win;
    public AudioClip attack;
    public AudioClip collect;
    public AudioClip jump;
    public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        SFXSource.clip = click;
        SFXSource.Play();
    }
}
