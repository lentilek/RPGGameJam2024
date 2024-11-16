using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToGhost;
    public GameObject credits;
    private void Start()
    {
        howToGhost.SetActive(false);
        credits.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HowToGhost()
    {
        howToGhost.SetActive(true);
        credits.SetActive(false);
    }
    public void Credits()
    {
        howToGhost.SetActive(false);
        credits.SetActive(true);
    }
    public void CloseStuff()
    {
        howToGhost.SetActive(false);
        credits.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
