using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject EndScreen;
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
        if(MusicManager.Instance != null)
        {
            MusicManager.Instance.newScene = true;
        }
    }
    private void Start()
    {
        pauseUI.SetActive(false);
        EndScreen.SetActive(false);
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
            Pause.Instance.instruction.SetActive(false);
            pauseUI.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
        }
        if(inPortal == 2 && SceneManager.GetActiveScene().buildIndex != 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if(inPortal == 2)
        {
            Time.timeScale = 0f;
            EndScreen.SetActive(true);
        }
    }
}
