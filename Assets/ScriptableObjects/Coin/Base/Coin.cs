using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kenneth Vedder. 2023

[CreateAssetMenu(fileName = "New Coin", menuName = "CoinClicker/Coin")]
public class Coin : ScriptableObject
{
    public Sprite coinSprite;
    public Color tint;
    public int worth;
}
