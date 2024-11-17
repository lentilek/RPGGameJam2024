using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    public GameObject object1, object2, object3;

    private GameObject player;

    public GameObject lever1, lever2;

    private void Start()
    {
        object3.SetActive(true);
        lever1.SetActive(true);
        lever2.SetActive(false);
    }
    private void Update()
    {
        if(player != null && Input.GetKeyDown(KeyCode.LeftShift) && player.GetComponent<Player1>() != null)
        {
            AudioManager.Instance.PlaySound("lever");
            object1.GetComponent<Animation>().enabled = true;
            lever1.SetActive(false);
            lever2.SetActive(true);
        }
        else if(player != null && Input.GetKeyDown(KeyCode.RightShift) && player.GetComponent<Player2>() != null)
        {
            AudioManager.Instance.PlaySound("lever");
            object2.GetComponent<Animator>().enabled = true;
            object3.SetActive(false);
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
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player1>() != null && Input.GetKeyDown(KeyCode.LeftShift))
            {
                //
            }
            else if (other.GetComponent<Player2>() != null && Input.GetKeyDown(KeyCode.RightShift))
            {
                object2.GetComponent<Animator>().enabled = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && other.GetComponent<Player1>() != null)
            {
                //
            }else if(Input.GetKeyDown(KeyCode.RightShift) && other.GetComponent<Player2>() != null)
            {
                object2.GetComponent<Animator>().enabled = true;
            }
        }
    }*/
}
