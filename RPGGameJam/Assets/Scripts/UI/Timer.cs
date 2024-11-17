using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public float maxTime;
    [HideInInspector] public float currentTime;
    public TextMeshProUGUI timerTxt;
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
        StopAllCoroutines();
        currentTime = maxTime;
    }
    void Start()
    {
        StartCoroutine(Timing());
    }

    IEnumerator Timing()
    {
        do
        {
            Display();
            yield return new WaitForSeconds(1f);
            currentTime--;
        } while (currentTime >= 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Display()
    {
        //float minutes = Mathf.FloorToInt(currentTime / 60);
        //float seconds = Mathf.FloorToInt(currentTime % 60);
        //timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerTxt.text = $"{minutes}:{seconds}";
        timerTxt.text = currentTime.ToString();
    }
}
