using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHear : MonoBehaviour
{
    private AudioSource audioSrc;
    public float volume = 1f;

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
