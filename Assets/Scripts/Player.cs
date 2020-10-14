using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    bool isJump;
    public float jumpPower;

    public int itemCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")&& !isJump)
        {
            isJump = true;
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }   
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "item")
        {
            itemCount++;
            other.gameObject.SetActive(false);
        }
    }
}
