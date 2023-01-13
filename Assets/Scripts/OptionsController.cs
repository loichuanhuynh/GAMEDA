using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsController : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onReturnToMainMenu()
    {
        audio.Play();
        SceneManager.LoadScene(0);
    }

    public void onPlay()
    {
        audio.Play();
        SceneManager.LoadScene(4);
    }

    public void onFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
