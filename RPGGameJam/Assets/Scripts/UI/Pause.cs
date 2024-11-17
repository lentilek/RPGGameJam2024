using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause Instance;    
    public GameObject instruction;

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
        instruction.SetActive(false);
    }
    public void Resume()
    {
        instruction.SetActive(false);
        GameManager.Instance.isPaused = false;
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Instruction()
    {
        instruction.SetActive(true);
    }
    public void InstructionClose()
    {
        instruction.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
