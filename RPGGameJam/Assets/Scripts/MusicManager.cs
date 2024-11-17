using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{ 
    public static MusicManager Instance;

    public AudioSource audioSrc1, audioSrc2;

    public bool newScene;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            Instance = this;
            return;
        }

        Destroy(gameObject);
        newScene = false;
        audioSrc1.Play();
        audioSrc2.Pause();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && newScene)
        {
            audioSrc1.Pause();
            audioSrc2.Play();
            newScene = false;
        }
        else if(audioSrc2.isPlaying && newScene)
        {
            audioSrc1.Play();
            audioSrc2.Pause();
            newScene = false;
        }
    }
}
