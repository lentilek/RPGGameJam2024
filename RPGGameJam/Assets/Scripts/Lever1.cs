using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<Player1>() != null && Input.GetKeyDown(KeyCode.LeftShift))
            {
                //
            }else if(other.GetComponent<Player2>() != null && Input.GetKeyDown(KeyCode.RightShift))
            {
                //
            }
        }
    }
}
