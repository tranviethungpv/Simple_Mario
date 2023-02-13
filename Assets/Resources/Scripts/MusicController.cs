using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TurnOnMusic()
    {
        audioSource.Play();
    }

    public void TurnOffMusic()
    {
        audioSource.Stop();
    }
}
