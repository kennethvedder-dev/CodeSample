using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by Kenneth Vedder. 2023

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;


    void Start()
    {
        _UIManager.overrideStart = true;
        _UIManager.SetAlphaValue(1);
        _UIManager.SetShadeValue(1);
        _UIManager.SetShade(false);
    }

    public void StartGame()
    {
        Invoke("LoadScene", _UIManager.shadeFadeSpeed); //I can make a custom load time variable
    }

    public void ExitGame()
    {
        _UIManager.SetShadeValue(1);
        _UIManager.SetShade(true);
        Invoke("Exit", _UIManager.shadeFadeSpeed);
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
