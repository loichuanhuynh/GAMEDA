using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Return");
    }

    public void onFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
