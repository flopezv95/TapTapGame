using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounterToTap : MonoBehaviour
{
    private StartAndEndGameManager gameOver;

    void Start()
    {
        gameOver = GameObject.FindGameObjectWithTag("Background").GetComponent<StartAndEndGameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameTapTapManager.gameIsStarted && !GameTapTapManager.gameIsComplete)
        {
            GameTapTapManager.timeToTapAnotherButton -= Time.deltaTime;
            if(GameTapTapManager.timeToTapAnotherButton <= 0.0f)
            {
                Debug.Log("GameOver");
                gameOver.GameOverTapAnotherButton();
            }
        }
    }
}
