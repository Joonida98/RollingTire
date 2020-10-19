using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;  // 리플레이시 출발
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
          
        }
    }
}
