using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoubleTap : MonoBehaviour
{
    public int numberOfTheButton = 0;
    public VisualLevelsManager.Modes modeTheGame;
    public bool isTapTapButton;


    private StartAndEndGameManager gameOver;
    private bool tapOneTime = false;
    private Color buttonColor;
    private bool colorAlreadyPushIt = false;

    void Start()
    {
        if (modeTheGame == VisualLevelsManager.Modes.ReverseMode)
        {
            GameTapTapManager.actualNumber = GameTapTapManager.numberOfButtonsToSpawn + 1;
            if (isTapTapButton)
            {
                numberOfTheButton = GameTapTapManager.numberOfButtonsToSpawn + 1;
            }
        }
        else
        {
            if(isTapTapButton)
            {
                numberOfTheButton = 0;
            }
        }
        gameOver = GameObject.FindGameObjectWithTag("Background").GetComponent<StartAndEndGameManager>();
    }

    public void DoubleTapFunction()
    {
        if (!GameTapTapManager.gameIsOver)
        {
            if (modeTheGame == VisualLevelsManager.Modes.ColorMode)
            {
                if (tapOneTime && GameTapTapManager.numberOfTheButtonsWithTheRigthColor > 0)
                {
                    if (numberOfTheButton != 0)
                    {
                        GameTapTapManager.numberOfTheButtonsWithTheRigthColor--;
                    }
                    tapOneTime = false;
                }
                else if ((buttonColor == GameTapTapManager.colorToPush && !colorAlreadyPushIt) ||(numberOfTheButton == 0 && (!colorAlreadyPushIt || GameTapTapManager.numberOfTheButtonsWithTheRigthColor <=0)))
                {
                    colorAlreadyPushIt = true;
                    ResetCounters();
                }
                else
                {
                    gameOver.GameOverByNumber();
                }
            }
            else
            {
                if (tapOneTime && numberOfTheButton == GameTapTapManager.actualNumber)
                {
                    tapOneTime = false;
                    if (modeTheGame == VisualLevelsManager.Modes.ReverseMode)
                    {
                        GameTapTapManager.actualNumber--;
                    }
                    else if (modeTheGame == VisualLevelsManager.Modes.OnlyPairsMode)
                    {
                        if (GameTapTapManager.actualNumber == GameTapTapManager.numberOfButtonsToSpawn)
                        {
                            GameTapTapManager.actualNumber++;
                        }
                        else
                        {
                            GameTapTapManager.actualNumber += 2;
                        }

                    }
                    else
                    {
                        GameTapTapManager.actualNumber++;
                    }
                }
                else if (numberOfTheButton == GameTapTapManager.actualNumber)
                {
                    ResetCounters();
                }
                else if ((GameTapTapManager.actualNumber - 1) >= 0 && GameTapTapManager.actualNumber - 1 != GameTapTapManager.numberOfButtonsToSpawn)
                {
                    gameOver.GameOverByNumber();
                }
            }
            Debug.Log(GameTapTapManager.timeToTapAnotherButton);
        }
    }

    void Update()
    {
        if (tapOneTime && !GameTapTapManager.gameIsOver && !GameTapTapManager.gameIsComplete)
        {
            GameTapTapManager.timeToTapMakeDoubleTap -= Time.deltaTime;
            if (GameTapTapManager.timeToTapMakeDoubleTap <= 0.0f)
            {
                Debug.Log("Lost for time in the double Tap");
                tapOneTime = false;
                gameOver.GameOverDoubleTap();
                GameTapTapManager.timeToTapMakeDoubleTap = 1.0f;
            }
        }
    }

    public void SetNumber(int number)
    {
        numberOfTheButton = number;
    }

    public void SetColor(Color colorToAdd)
    {
        GetComponent<Image>().color = colorToAdd;
        buttonColor = colorToAdd;
    }

    private void ResetCounters()
    {
        tapOneTime = true;
        GameTapTapManager.timeToTapMakeDoubleTap = GameTapTapManager.originaltimeToTapMakeDoubleTap;
        GameTapTapManager.timeToTapAnotherButton = GameTapTapManager.originalTimeToTapAnotherButton;
    }
}


