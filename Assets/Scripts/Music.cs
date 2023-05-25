using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip gameSong;
    private AudioSource aSrc;

    void Start()
    {   
        aSrc = GetComponent<AudioSource>();

        PlayMusic();

        DontDestroyOnLoad(this.gameObject);
    }

    void PlayMusic()
    {
        aSrc.PlayOneShot(gameSong);
    }
}
