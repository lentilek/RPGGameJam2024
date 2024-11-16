using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject disapearThis;
    public bool isSeen = true;

    public GameObject buttonRed;
    public GameObject buttonGreen;

    private void Start()
    {
        disapearThis.SetActive(isSeen);
        buttonRed.SetActive(true);
        buttonGreen.SetActive(false);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > transform.position.y)
        {
            Debug.Log("uwu");
            disapearThis.SetActive(!isSeen);
            buttonRed.SetActive(false);
            buttonGreen.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            disapearThis.SetActive(isSeen);
            buttonRed.SetActive(true);
            buttonGreen.SetActive(false);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.transform.position.y > transform.position.y)
        {
            //Debug.Log("uwu");
            disapearThis.SetActive(!isSeen);
            buttonRed.SetActive(false);
            buttonGreen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            disapearThis.SetActive(isSeen);
            buttonRed.SetActive(true);
            buttonGreen.SetActive(false);
        }
    }
}
