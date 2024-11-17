using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public int leverNumber;
    public GameObject lightning, column;

    private GameObject player;

    public GameObject lever1, lever2;

    private void Start()
    {
        lightning.SetActive(true);
        lever1.SetActive(true);
        lever2.SetActive(false);
    }
    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.LeftShift) && leverNumber == 1)
        {
            AudioManager.Instance.PlaySound("lever");
            column.GetComponent<Animator>().enabled = true;
            lever1.SetActive(false);
            lever2.SetActive(true);
        }
        else if (player != null && Input.GetKeyDown(KeyCode.LeftShift) && leverNumber == 2)
        {
            AudioManager.Instance.PlaySound("lever");
            lightning.SetActive(false);
            lever1.SetActive(false);
            lever2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
    /*public int leverNumber;
    public GameObject lightning;
    private void Start()
    {
        lightning.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {o
            if (ther.GetComponent<Player1>() != null && Input.GetKeyDown(KeyCode.LeftShift) && leverNumber == 1)
            {
                // animacja podnoszenia platformy
            }
            else if (other.GetComponent<Player1>() != null && Input.GetKeyDown(KeyCode.LeftShift) && leverNumber == 2)
            {
                lightning.SetActive(false);
            }
        }
    }*/
}
