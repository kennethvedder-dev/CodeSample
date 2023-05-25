using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

public class CoinVFX : MonoBehaviour
{
    public float disableInThisTime;

    void OnEnable()
    {
        Invoke("DisableObject", disableInThisTime);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
