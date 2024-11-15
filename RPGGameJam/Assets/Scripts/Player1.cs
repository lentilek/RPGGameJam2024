using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveForceGround;
    public float moveForceAir;
    public float jumpForce;
    private Rigidbody rb;
    public bool isOnGround;
    //private PlayerInput playerInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (isOnGround)
            {
                this.transform.position += Vector3.right * moveForceGround * Time.deltaTime;
            }
            else
            {
                this.transform.position += Vector3.right * moveForceAir * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(isOnGround)
            {
                this.transform.position -= Vector3.right * moveForceGround * Time.deltaTime;
            }
            else
            {
                this.transform.position -= Vector3.right * moveForceAir * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround) //&& = AND operator
        {
            isOnGround = false; 
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}
