using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        
    }
    
    public void onNewGame()
    {
        audio.Play();
        Debug.Log("New Game");
    }

    public void onLoadGame()
    {
        audio.Play();
        Debug.Log("Load Game");
    }

    public void onOptions()
    {
        audio.Play();
        Debug.Log("Options");
    }
    
    public void onExit()
    {
        audio.Play();
        Debug.Log("Exit");
        Application.Quit();
    }
}
