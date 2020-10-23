using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool TapToStat; //터치 후 게임 시작
    public GameObject StartText; // 터치 후 글씨 제거

    public static int numberOfCoin;
    public Text countCoins;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;  // 리플레이 후 다시 출발
        TapToStat = false;
        numberOfCoin = 0;
    }

    
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
          
        }

        countCoins.text = "Coins: " + numberOfCoin;


        if(SwipeManager.tap)
        {
            TapToStat = true;
            Destroy(StartText);
        }
    }
}
