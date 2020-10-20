using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    public bool isGround;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;

    private int gameLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; // 이동가능한 레인의 폭

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        isGround = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        if (isGround)
        {
            direction.y = -2;
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
            else
                direction.y += Gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeRight)
        {
            gameLane++;
            if (gameLane == 3)
            {
                gameLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            gameLane--;
            if (gameLane == -1)
            {
                gameLane = 0;
            }
        }

        Vector3 targetPosition = (transform.position.z * transform.forward) + (transform.position.y * transform.up);

        if (gameLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(gameLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 30 * Time.deltaTime);
        controller.center = controller.center;
     

    }

    void Jump()
    {
        direction.y = jumpForce;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag =="Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}
