using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject pauseUI;
    [HideInInspector] public bool isPaused;
    [HideInInspector] public int inPortal;
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
    private void Start()
    {
        pauseUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        inPortal = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
        if(inPortal == 2 && SceneManager.GetActiveScene().buildIndex != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
