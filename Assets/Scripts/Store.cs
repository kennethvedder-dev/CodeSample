using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Written by Kenneth Vedder. 2023

public class Store : MonoBehaviour
{
    public int chestPrice;
    public Chest[] chestsInStock;

    [Header("Events")]
    public UnityEvent availableChestEvent;

    [Header("External logic")]
    public Player _Player;
    public ChestScreen _ChestScreen;

    void Start()
    {
        if(!_Player)
            _Player = gameObject.GetComponent<Player>();
    }


    //Playable logic

    public void CheckPlayerCoinBalance()
    {
        if(_Player.coinAmount >= chestPrice && _Player.chestAmount != chestsInStock.Length)
        {
            Debug.Log("Player has coins to buy a chest. Call the chest display event");
            ShowChestPurchase();
        }
    }

    public void ShowChestPurchase()
    {
        availableChestEvent.Invoke();
        _ChestScreen.gameObject.SetActive(true);
    }
}   
