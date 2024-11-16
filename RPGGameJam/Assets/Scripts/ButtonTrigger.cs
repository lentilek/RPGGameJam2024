using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject disapearThis;

    private void Start()
    {
        disapearThis.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > transform.position.y)
        {
            disapearThis.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            disapearThis.SetActive(true);
        }
    }
}
