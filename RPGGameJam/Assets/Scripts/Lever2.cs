using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public int leverNumber;
    public GameObject lightning;
    private void Start()
    {
        lightning.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player1>() != null && Input.GetKeyDown(KeyCode.LeftShift) && leverNumber == 1)
            {
                // animacja podnoszenia platformy
            }
            else if (other.GetComponent<Player1>() != null && Input.GetKeyDown(KeyCode.LeftShift) && leverNumber == 2)
            {
                lightning.SetActive(false);
            }
        }
    }
}
