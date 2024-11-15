using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    private bool isPaused;

    private void Start()
    {
        pauseUI.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseUI.SetActive(true);
            isPaused = true;
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(false);
            isPaused = false;
        }
    }
}
