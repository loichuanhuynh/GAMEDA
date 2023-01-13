using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource audioSource;
    public Audios audios;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Play(int i)
    {
        audioSource.PlayOneShot(audios.audios[i]);
    }
}
