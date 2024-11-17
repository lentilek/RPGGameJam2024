using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntructionStart : MonoBehaviour
{
    public GameObject toClose;
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            toClose.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            toClose.SetActive(false);
        }
    }
    public void CloseInstruction()
    {
        Time.timeScale = 1f;
        toClose.SetActive(false);
    }
}
