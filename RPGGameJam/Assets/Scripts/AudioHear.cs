using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHear : MonoBehaviour
{
    private AudioSource audioSrc;
    public float volume = 1f;
    public bool once = false;
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = volume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSrc.Play();
            if(once)
            {
                audioSrc.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSrc.Stop();
        }
    }
}
