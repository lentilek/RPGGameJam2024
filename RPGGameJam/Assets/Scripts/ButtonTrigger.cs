using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject disapearThis;
    public bool isSeen = true;

    private void Start()
    {
        disapearThis.SetActive(isSeen);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > transform.position.y)
        {
            disapearThis.SetActive(!isSeen);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            disapearThis.SetActive(isSeen);
        }
    }
}
