﻿using System.Collections;
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

    private int gameLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; // 이동가능한 레인의 폭

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameLane++;
            if (gameLane == 3)
            {
                gameLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
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

        transform.position = targetPosition;
        // Vector3.Lerp(transform.position, targetPosition, 30 * Time.deltaTime); >> 적용 시 이상한 진동이 발생



    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

}
