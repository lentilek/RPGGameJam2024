using System.Collections;
using System.Collections.Generic;
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
    [HideInInspector] public bool inPortal;
    [SerializeField] private Animator anim;
    public GameObject graphic;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pushDirection = 0;
        inPortal = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && !inPortal)
        {
            if (isOnGround)
            {
                anim.SetBool("isWalkingRight", true);
                this.transform.position += Vector3.right * moveForceGround * Time.deltaTime;
                if(pushDirection == 1)
                {
                    pushable.transform.position += Vector3.right * moveForceGround * Time.deltaTime;
                }
            }
            else
            {
                anim.SetBool("isWalkingRight", false);
                this.transform.position += Vector3.right * moveForceAir * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A) && !inPortal)
        {
            if(isOnGround)
            {
                anim.SetBool("isWalkingLeft", true);
                this.transform.position -= Vector3.right * moveForceGround * Time.deltaTime;
                if (pushDirection == 2)
                {
                    pushable.transform.position -= Vector3.right * moveForceGround * Time.deltaTime;
                }
            }
            else
            {
                anim.SetBool("isWalkingLeft", false);
                this.transform.position -= Vector3.right * moveForceAir * Time.deltaTime;
            }
        }
        else if (!inPortal)
        {
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround && !inPortal)
        {
            AudioManager.Instance.PlaySound("jump");
            isOnGround = false;
            anim.SetBool("isInAir", true);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            anim.SetBool("isInAir", false);
        }
        if (collision.gameObject.tag == "Movable")
        {
            anim.SetBool("isInAir", false);
            isOnGround = true;
            pushable = collision.gameObject;
            if (this.transform.position.x < pushable.transform.position.x && (this.transform.position.y - pushable.transform.position.y) < 1f)//this.transform.position.y <= pushable.transform.position.y)
            {
                pushDirection = 1; // right
            }
            else if ((this.transform.position.y - pushable.transform.position.y) < 1f)//(this.transform.position.y <= pushable.transform.position.y)
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
