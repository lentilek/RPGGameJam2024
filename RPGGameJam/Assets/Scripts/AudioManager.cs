using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip button, lever, portal, jump;

    public float buttonVolume = 1f, leverVolume = 1f, portalVolume = 1f, jumpVolume = 1f;

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
                audioSrc.PlayOneShot(button, buttonVolume);
                break;
            case "lever":
                audioSrc.PlayOneShot(lever, leverVolume);
                break;
            case "portal":
                audioSrc.PlayOneShot(portal, portalVolume);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump, jumpVolume);
                break;
            default:
                break;
        }
    }
}
