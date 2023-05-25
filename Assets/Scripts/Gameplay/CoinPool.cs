using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

public class CoinPool : MonoBehaviour
{
    public CoinObject[] coins;
    [SerializeField] private int howManyToPick;
    [SerializeField] private int howManyToGive;
    
    void Start()
    {
        ScanCoins();
    }

    void ScanCoins()
    {
        coins = GetComponentsInChildren<CoinObject>();
    }

    public void SetInteraction(bool state)
    {
        ScanCoins();

        foreach(CoinObject coin in coins)
        {
            if(!coin.picked)
            {
                coin.interactive = state;
            }
            else
            {
                //Debug.Log($"Coin{coin.gameObject.name} was already picked");
            }
        }
    }

    public void HowManyInteractable() 
    {
        ScanCoins();
        howManyToPick = 0;

        foreach(CoinObject coin in coins)
        {
            if(!coin.picked)
            {
                howManyToPick++;
            }
        }

        if(howManyToPick < howManyToGive)
        {
            CallDeficit();
        }
    }

    void CallDeficit()
    {
        Debug.Log("We have less than we need. Calling for more");

        for(int i = 0; i < howManyToGive; i++)
        {
            coins[i].picked = false;
            coins[i].RandomizePos();
        }
    }

    public void PickAllCoins() //To get called once game goal has been met
    {
        foreach(CoinObject coin in coins)
        {
            coin.PickCoin();
        }
    }
}
