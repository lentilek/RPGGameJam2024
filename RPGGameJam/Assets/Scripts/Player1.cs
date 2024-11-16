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
    public int pushDirection;
    private GameObject pushable;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pushDirection = 0;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (isOnGround)
            {
                this.transform.position += Vector3.right * moveForceGround * Time.deltaTime;
                if(pushDirection == 1)
                {
                    pushable.transform.position += Vector3.right * moveForceGround * Time.deltaTime;
                }
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
                if (pushDirection == 2)
                {
                    pushable.transform.position -= Vector3.right * moveForceGround * Time.deltaTime;
                }
            }
            else
            {
                this.transform.position -= Vector3.right * moveForceAir * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
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
        if (collision.gameObject.tag == "Movable")
        {
            isOnGround = true;
            pushable = collision.gameObject;
            if (this.transform.position.x < pushable.transform.position.x && this.transform.position.y <= pushable.transform.position.y)
            {
                pushDirection = 1; // right
            }
            else if (this.transform.position.y <= pushable.transform.position.y)
            {
                pushDirection = 2; // left
            }
            else
            {
                pushDirection = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Movable")
        {
            pushDirection = 0;
            pushable = null;
        }
    }
}
