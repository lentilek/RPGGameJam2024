using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player1, player2;
    //private bool isInside;
    private void Start()
    {
        //isInside = false;
    }
    private void Update()
    {
        if (player1 != null && Input.GetKeyDown(KeyCode.LeftShift) && player1.GetComponent<Player1>() != null && !player1.GetComponent<Player1>().inPortal)
        {
            AudioManager.Instance.PlaySound("portal");
            //Debug.Log("uwu");
            GameManager.Instance.inPortal++;
            //isInside = true;
            player1.GetComponent<Player1>().inPortal = true;
            player1.GetComponent<Player1>().graphic.SetActive(false);
            player1.GetComponent<BoxCollider>().enabled = false;
        }
        else if (player2 != null && Input.GetKeyDown(KeyCode.RightShift) && player2.GetComponent<Player2>() != null && !player2.GetComponent<Player2>().inPortal)
        {
            AudioManager.Instance.PlaySound("portal");
            //Debug.Log("owo");
            GameManager.Instance.inPortal++;
            //isInside = true;
            player2.GetComponent<Player2>().inPortal = true;
            player2.GetComponent <Player2>().graphic.SetActive(false);
            player2.GetComponent<BoxCollider>().enabled = false;
        }
        else if(player1 != null && player1.GetComponent<Player1>() != null && player1.GetComponent<Player1>().inPortal && Input.GetKeyDown(KeyCode.LeftShift))// || Input.GetKeyDown(KeyCode.RightShift)))
        {
            //Debug.Log("uwu");
            //isInside = false;
            GameManager.Instance.inPortal--;
            player1.GetComponent<Player1>().inPortal = false;
            player1.GetComponent<Player1>().graphic.SetActive(true);
            player1.GetComponent<BoxCollider>().enabled = true;
        }
        else if (player2 != null && player2.GetComponent<Player2>() != null && player2.GetComponent<Player2>().inPortal && Input.GetKeyDown(KeyCode.RightShift))
        {
            //Debug.Log("owo");
            //isInside = false;
            GameManager.Instance.inPortal--;
            player2.GetComponent<Player2>().inPortal = false;
            player2.GetComponent<Player2>().graphic.SetActive(true);
            player2.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player1>())
            {
                player1 = other.gameObject;
            }
            else if (other.GetComponent<Player2>())
            {
                player2 = other.gameObject;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player1>())
            {
                player1 = other.gameObject;
            }
            else if(other.GetComponent<Player2>())
            {
                player2 = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player1>())
            {
                player1 = null;
            }
            else if (other.GetComponent<Player2>())
            {
                player2 = null;
            }
        }
    }
}
