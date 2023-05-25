using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

public class ChestScreen : MonoBehaviour
{
    public GameObject CanvasScreen; // could make calls to this from the GFX script reference?
    public bool automaticExit;
    [SerializeField] private float loadOutTime;

    [Header("External logic")]
    public UIManager _UIManager;
    public Store _Store; //Just so GFX can bridge the info
    public ChestGFX _ChestGFX;

    public void BoughtChest()
    {
        _ChestGFX.OpenChest();

        if(automaticExit)
        {
            Invoke("DisableScreen", _ChestGFX.sequenceTime);
        }
        else
        {     
        }
    }

    public void EnableScreen()
    {
        //enable all objects here, in order to not call gameobjects as active in the events themselves
        gameObject.SetActive(true);
        CanvasScreen.SetActive(true);
        //call methods
        _UIManager.SequenceState(true);
        _ChestGFX.StartSequence();
    }

    public void DisableScreen()
    {
        _ChestGFX.GoAway();
        
        Invoke("DisableElements", loadOutTime);
    }

    void DisableElements()
    {
        gameObject.SetActive(false);
        CanvasScreen.SetActive(false);
    }
}
