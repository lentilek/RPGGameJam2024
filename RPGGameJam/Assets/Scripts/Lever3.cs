using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{
    public int leverNumber;
    public GameObject bridge1, bridge2, bridge3;

    private GameObject player;

    public GameObject lever1, lever2;

    private void Start()
    {
        //lightning.SetActive(true);
        lever1.SetActive(true);
        lever2.SetActive(false);
    }
    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.RightShift) && leverNumber == 1)
        {
            //column.GetComponent<Animator>().enabled = true;
            lever1.SetActive(false);
            lever2.SetActive(true);
        }
        else if (player != null && Input.GetKeyDown(KeyCode.RightShift) && leverNumber == 2)
        {
            //lightning.SetActive(false);
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
}
