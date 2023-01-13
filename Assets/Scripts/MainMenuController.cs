using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        
    }
    
    public void onNewGame()
    {
        audio.Play();
        SceneManager.LoadScene(2);
    }

    public void onLoadGame()
    {
        audio.Play();
        Debug.Log("Load Game");
    }

    public void onOptions()
    {
        audio.Play();
        SceneManager.LoadScene(1);
    }
    
    public void onExit()
    {
        audio.Play();
        Debug.Log("Exit");
        Application.Quit();
    }
}
