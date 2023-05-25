using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

[CreateAssetMenu(fileName = "New Chest", menuName = "CoinClicker/Chest")]
public class Chest : ScriptableObject
{
    public string Name;

    [Header("Card Info")]
    public Sprite cardSprite;
    public string cardName;
    public string cardDescription;
}
