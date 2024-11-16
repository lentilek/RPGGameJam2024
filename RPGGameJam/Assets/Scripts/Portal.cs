using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;
    private bool isInside;
    private void Start()
    {
        isInside = false;
    }
    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.LeftShift) && player.GetComponent<Player1>() != null && !isInside)
        {
            Debug.Log("uwu");
            GameManager.Instance.inPortal++;
            isInside = true;
            player.GetComponent<Player1>().inPortal = true;
        }
        else if (player != null && Input.GetKeyDown(KeyCode.RightShift) && player.GetComponent<Player2>() != null && !isInside)
        {
            Debug.Log("owo");
            GameManager.Instance.inPortal++;
            isInside = true;
            player.GetComponent<Player2>().inPortal = true;
        }
        else if(isInside && Input.GetKeyDown(KeyCode.LeftShift) && player.GetComponent<Player1>() != null)// || Input.GetKeyDown(KeyCode.RightShift)))
        {
            Debug.Log("uwu");

            isInside = false;
            GameManager.Instance.inPortal--;
            player.GetComponent<Player1>().inPortal = false;
        }else if(isInside && Input.GetKeyDown(KeyCode.RightShift) && player.GetComponent<Player2>() != null)
        {
            Debug.Log("owo");

            isInside = false;
            GameManager.Instance.inPortal--;
            player.GetComponent<Player2>().inPortal = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            //Debug.Log("uwu");
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
