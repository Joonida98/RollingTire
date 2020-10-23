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
    public float maxSpeed;

    public bool isGround;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce = 12;
    public float gravity = -10;

    private int gameLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; // 이동가능한 레인의 폭

    public Animator animatior;
    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!PlayerManager.TapToStat)
            return;

        if (forwardSpeed < maxSpeed)  //속도증가
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        animatior.SetBool("TapToStart", true);
        direction.z = forwardSpeed;

        isGround = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);
        animatior.SetBool("isGrounded", isGround);
        if (isGround)
        {
           direction.y = 0;
            if (SwipeManager.swipeUp)
            {
                FindObjectOfType<AudioManager>().PlaySound("Jump");
                direction.y = jumpForce;
            }
        }
        else
            direction.y += gravity * Time.deltaTime;
        
        
        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }


        controller.Move(direction * Time.deltaTime);

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

    
   
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag =="Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
    private void FixedUpdate()
    {
        if (!PlayerManager.TapToStat)
            return;
    }
    private IEnumerator Slide()
    {
        isSliding = true;
        animatior.SetBool("isSliding", true);             
        controller.center = new Vector3(0, -0.5f, 0);   
        controller.height = 1;

        yield return new WaitForSeconds(0.8f); //슬라이드 시간

        controller.center = new Vector3(0, 0, 0);
        controller.height = 0;
        animatior.SetBool("isSliding", false);
        isSliding = false;
    }
}
