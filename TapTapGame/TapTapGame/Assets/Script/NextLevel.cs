using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string levelName;
    public string levelNextModeName;
    public float firstTimeLevel = 0;
    public float secondTimeLevel = 0;
    public float thirdTimeLevel = 0;
    public int firstButtonToSpawn = 0;
    public int secondButtonToSpawn = 0;
    public int thirdButtonToSpawn = 0;
    public float firstTimeToDissaperNumber = 0;
    public float secondTimeToDissaperNumber = 0;
    public float thirdTimeToDissaperNumber = 0;
    public float timeToStartNextLevel = 0;
    public int numberButtonTospawnInTheNextLevel = 0;
    public float timeToDissaperNumberInTheNextLevel = 0;


    //public VisualLevelsManager.Modes modeTheGame;

    private bool nextMode = false;

    public void NextLevelFunction()
    {
        //Time
        if(GameTapTapManager.timeToTapAnotherButton == firstTimeLevel)
        {
            if (GameTapTapManager.numberOfButtonsToSpawn == thirdButtonToSpawn)
            {
                GameTapTapManager.timeToTapAnotherButton = secondTimeLevel;
                GameTapTapManager.originalTimeToTapAnotherButton = secondTimeLevel;
            }
        }
        else if(GameTapTapManager.timeToTapAnotherButton == secondTimeLevel)
        {
            if (GameTapTapManager.numberOfButtonsToSpawn == thirdButtonToSpawn)
            {
                GameTapTapManager.timeToTapAnotherButton = thirdTimeLevel;
                GameTapTapManager.originalTimeToTapAnotherButton = thirdTimeLevel;
            }
        }
        else if(GameTapTapManager.timeToTapAnotherButton == thirdTimeLevel)
        {
            if(GameTapTapManager.numberOfButtonsToSpawn == thirdButtonToSpawn)
            {
                GameTapTapManager.timeToTapAnotherButton = timeToStartNextLevel;
                GameTapTapManager.originalTimeToTapAnotherButton = timeToStartNextLevel;
                GameTapTapManager.timeBeforeNumbersDissaper = timeToDissaperNumberInTheNextLevel;
                nextMode = true;
            }
        }
        else
        {
            Debug.Log("ATTENTION YOU PUT A INVALID TIME");
        }
        //NumbersOfBottons
        if(GameTapTapManager.numberOfButtonsToSpawn == firstButtonToSpawn)
        {
            GameTapTapManager.numberOfButtonsToSpawn = secondButtonToSpawn;
        }
        else if(GameTapTapManager.numberOfButtonsToSpawn == secondButtonToSpawn)
        {
            GameTapTapManager.numberOfButtonsToSpawn = thirdButtonToSpawn;
        }
        else if(GameTapTapManager.numberOfButtonsToSpawn == thirdButtonToSpawn)
        {
            if(nextMode)
            {
                GameTapTapManager.numberOfButtonsToSpawn = numberButtonTospawnInTheNextLevel;
            }
            else
            {
                GameTapTapManager.numberOfButtonsToSpawn = firstButtonToSpawn;
            }
        }
        else
        {
            Debug.Log("ATTENTION YOU PUT A INVALID NUMBER OF BUTTONS");
        }
        //TimeToDissapearTheNumbers
        if(firstTimeToDissaperNumber !=0 && secondTimeToDissaperNumber != 0 && thirdTimeToDissaperNumber != 0)
        {
            if (GameTapTapManager.timeBeforeNumbersDissaper % firstTimeToDissaperNumber == 0)
            {
                if (GameTapTapManager.numberOfButtonsToSpawn == firstButtonToSpawn)
                {
                    GameTapTapManager.timeBeforeNumbersDissaper = secondTimeToDissaperNumber;
                }
                else
                {
                    GameTapTapManager.timeBeforeNumbersDissaper += firstTimeToDissaperNumber;
                }
            }
            else if (GameTapTapManager.timeBeforeNumbersDissaper % secondTimeToDissaperNumber == 0)
            {
                if (GameTapTapManager.numberOfButtonsToSpawn == firstButtonToSpawn)
                {
                    GameTapTapManager.timeBeforeNumbersDissaper = thirdTimeToDissaperNumber;
                }
                else
                {
                    GameTapTapManager.timeBeforeNumbersDissaper += secondTimeToDissaperNumber;
                }
            }
            else
            {
                GameTapTapManager.timeBeforeNumbersDissaper += thirdTimeToDissaperNumber;
            }
        }

        if (nextMode)
        {
            GameTapTapManager.levelToUnlock = 1;
            SceneManager.LoadScene(levelNextModeName);
        }
        else
        {
            GameTapTapManager.levelToUnlock++;
            SceneManager.LoadScene(levelName);
        }
        
    }

}
