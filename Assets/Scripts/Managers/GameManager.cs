using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; //Should it be another script?

//Written by Kenneth Vedder. 2023

public class GameManager : MonoBehaviour
{
    public int chestsToFinish; //chests to have to finish the game
    [Header("Game Events")]
    public UnityEvent gameIsOver;
    [Header("Managers")]
    public UIManager _UIManager;
    [Header("Game Scripts")]
    public Player _Player;
    public Store _Store;

    void Start()
    {
        //setting both values in order for the game to fade in from completely black
        _UIManager.SetAlphaValue(1);
        _UIManager.SetShadeValue(1);
        
        //Set components
        if(!_Player)
        {
            _Player = gameObject.GetComponent<Player>();
        }

        //Set goal according to amount of chests.
        chestsToFinish = _Store.chestsInStock.Length;
    }

    public void CheckProgress() 
    {
        if(_Player.chestAmount == chestsToFinish && !_UIManager.inSequence) //if the player already has the 3 chests and we're not on a sequence, call for last event
        {
            gameIsOver.Invoke();
            Debug.Log("Player has accomplished the goal");
        }
        else
        {
            Debug.Log("Player has to play more");
        }
    }


    public void RestartScene()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exiting the game...");
    }
}
