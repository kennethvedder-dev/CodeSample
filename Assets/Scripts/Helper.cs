using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

public class Helper : MonoBehaviour
{
    public Player _Player;
    public Store _Store;

    public void AddChest()
    {
        if(_Player.coinAmount >= _Store.chestPrice) //do we have have enough coins?
        {
            _Player.coinAmount -= _Store.chestPrice;
            _Player.chestAmount++;
        }
        else
        {
            Debug.Log("You don't have enough coins to get a chest.");
        }
    }
}
