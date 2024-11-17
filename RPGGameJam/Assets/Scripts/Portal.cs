using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;
    //private bool isInside;
    private void Start()
    {
        //isInside = false;
    }
    private void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.LeftShift) && player.GetComponent<Player1>() != null && !player.GetComponent<Player1>().inPortal)
        {
            //Debug.Log("uwu");
            GameManager.Instance.inPortal++;
            //isInside = true;
            player.GetComponent<Player1>().inPortal = true;
        }
        else if (player != null && Input.GetKeyDown(KeyCode.RightShift) && player.GetComponent<Player2>() != null && !player.GetComponent<Player2>().inPortal)
        {
            //Debug.Log("owo");
            GameManager.Instance.inPortal++;
            //isInside = true;
            player.GetComponent<Player2>().inPortal = true;
        }
        else if(player != null && player.GetComponent<Player1>() != null && player.GetComponent<Player1>().inPortal && Input.GetKeyDown(KeyCode.LeftShift))// || Input.GetKeyDown(KeyCode.RightShift)))
        {
            //Debug.Log("uwu");
            //isInside = false;
            GameManager.Instance.inPortal--;
            player.GetComponent<Player1>().inPortal = false;
        }else if (player != null && player.GetComponent<Player2>() != null && player.GetComponent<Player2>().inPortal && Input.GetKeyDown(KeyCode.RightShift))
        {
            //Debug.Log("owo");
            //isInside = false;
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
