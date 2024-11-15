using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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
        if (Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isOnGround)
            {
                this.transform.position -= Vector3.right * moveForceGround * Time.deltaTime;
            }
            else
            {
                this.transform.position -= Vector3.right * moveForceAir * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround) //&& = AND operator
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
