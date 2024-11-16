using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class DeathZone : MonoBehaviour
{
    //public Animator transition;
    //public float transitionTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    /*Enumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }*/
}
