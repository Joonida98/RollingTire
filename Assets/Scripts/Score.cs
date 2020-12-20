﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text MainText;
    public Text scoreText;
    private float startTime;
    private bool finished = false;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (finished)
            return;

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        MainText.text = "SCORE "+ " : " +minutes + seconds + "M";
        scoreText.text = "SCORE " + " : " + minutes + seconds + "M";
    }
    public void Finish()
    {
        finished = true;
        scoreText.color = Color.yellow;
    }
}
