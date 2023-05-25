using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Update to be performed by UI manager

//Written by Kenneth Vedder. 2023

public class Player : MonoBehaviour
{
    public int coinAmount;
    public int chestAmount;

    //This should be done by a UI manager
    public Text coinDisplay;
    public Text chestDisplay;


    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        coinDisplay.text = coinAmount.ToString();
        chestDisplay.text = chestAmount.ToString();
    }
}
