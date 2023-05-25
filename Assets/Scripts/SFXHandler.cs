using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

public class SFXHandler : MonoBehaviour
{
    private AudioSource aSrc;

    void Start()
    {
        aSrc = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        aSrc.PlayOneShot(clip);
    }
}
