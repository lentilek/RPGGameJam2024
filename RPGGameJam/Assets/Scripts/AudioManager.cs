using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip button, cuckoo, lever, gameOver, portal, jump;

    [HideInInspector] public AudioSource audioSrc;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
    }
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public void PlaySound(string clip)
    {
        switch(clip)
        {
            case "button":
                audioSrc.PlayOneShot(button);
                break;
            case "cuckoo":
                audioSrc.PlayOneShot(cuckoo); 
                break;
            case "lever":
                audioSrc.PlayOneShot(lever);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOver);
                break;
            case "portal":
                audioSrc.PlayOneShot(portal);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            default:
                break;
        }
    }
}
