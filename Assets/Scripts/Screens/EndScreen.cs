using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//Written by Kenneth Vedder. 2023

public class EndScreen : MonoBehaviour
{
    private Animation animComp;
    public Text endScore;
    [SerializeField] private float loadOutTime;
    
    [Header("External logic")]
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private Player _Player;

    void Awake()
    {
        animComp = GetComponent<Animation>();

        //setting value to fade completely to black. Maybe an event?
        _UIManager.SetShadeValue(1);
        _UIManager.SetShade(true);

        PlayClip("Start");
    }

    public void GetScoreFromSession()
    {
        if(_Player.coinAmount == 1)
        {
            endScore.text = $"In this round you got {_Player.coinAmount} coin and all the {_Player.chestAmount} cards";
        }
        else
        {
            endScore.text = $"In this round you got {_Player.coinAmount} coins and all the {_Player.chestAmount} cards";
        }
    }

    public void PlayClip(string clipName)
    {
        animComp.Play(clipName);
    } 

    public void RestartGame()
    {
        PlayClip("FadeOut");
        Invoke("LoadScene", loadOutTime);
    }

    public void ExitGame()
    {
        PlayClip("FadeOut");
        Invoke("Exit", loadOutTime);
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    void Exit()
    {
        Application.Quit();
        Debug.Log("Exiting the game...");
    }
}
