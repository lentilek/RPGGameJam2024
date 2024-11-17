using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
{
    public GameObject bridge;

    private GameObject player;

    public GameObject lever1, lever2;

    private void Start()
    {
        lever1.SetActive(true);
        lever2.SetActive(false);
    }
    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.RightShift))
        {
            bridge.GetComponent<Animator>().enabled = true;
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
