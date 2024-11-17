using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    private void Start()
    {
        credits.SetActive(false);
        Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        credits.SetActive(true);
    }
    public void CloseStuff()
    {
        credits.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
