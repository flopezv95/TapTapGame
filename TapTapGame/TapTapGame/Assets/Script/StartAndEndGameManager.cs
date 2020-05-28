using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartAndEndGameManager : MonoBehaviour
{
    public GameObject startInstructions;
    public GameObject buttonToSpawn;
    public List<GameObject> positionsToSpawn;
    public GameObject gameCompleteMessage;
    public GameObject gameOverMessageByDoubleTap;
    public GameObject gameOverMessageAnotherButton;
    public GameObject gameOverByNumberMessage;
    public GameObject messageToSpawn;
    public GameObject positionForSpawnMessage;
    public VisualLevelsManager.Modes modeTheGame;

    private Vector3 boundaries;
    private Vector3 buttonPosition;
    private Vector3 tapTapButtonPosition;

    private GameObject[] buttons;
    private RectTransform rt;
    private RectTransform rtTapTap;
    private bool tapOneTimeStart = false;
    private bool winCondition = false;
    private Color[] colors = {Color.green, Color.red, Color.magenta, Color.blue};
    private int[] colorsNumbers = { 0, 0, 0, 0 };

    void Start()
    {
        if(GameTapTapManager.levelToUnlock == 1)
        {
            startInstructions.SetActive(true);
        }
        else
        {
            StartTheGame();
        }
    }

    public void StartTheGame()
    {
        if (GameTapTapManager.buttonsInTheGame.ToArray().Length > 0)
        {
            GameTapTapManager.buttonsInTheGame.Clear();
        }
        if (GameTapTapManager.numberOfButtonsToSpawn <= GameTapTapManager.maxButtonsInTheScreen && positionsToSpawn.ToArray().Length != 0)
        {
            GameTapTapManager.gameIsComplete = false;

            if (buttonToSpawn != null)
            {
                rt = buttonToSpawn.GetComponent<RectTransform>();
                buttons = new GameObject[GameTapTapManager.numberOfButtonsToSpawn];
                for (int i = 0; i < GameTapTapManager.numberOfButtonsToSpawn; i++)
                {
                    DefineButtonPosition();
                    SpawnButton(i);
                }
            }
            else
            {
                Debug.Log("Miss the prefab bottomObject or the taptap Button");
            }

            if (messageToSpawn != null)
            {
                if (modeTheGame == VisualLevelsManager.Modes.ColorMode)
                {
                    int indexColorToUse = 0;
                    int numToCompare = 0;
                    for (int i = 0; i < colorsNumbers.Length; i++)
                    {
                        if (colorsNumbers[i] > numToCompare)
                        {
                            numToCompare = colorsNumbers[i];
                            indexColorToUse = i;
                        }
                    }
                    Text ColorTextMessage = messageToSpawn.GetComponentInChildren<Text>();
                    switch (indexColorToUse)
                    {
                        case 0:
                            ColorTextMessage.text = "GREEN";
                            break;
                        case 1:
                            ColorTextMessage.text = "RED";
                            break;
                        case 2:
                            ColorTextMessage.text = "MAGENTA";
                            break;
                        case 3:
                            ColorTextMessage.text = "BLUE";
                            break;
                    }
                    GameTapTapManager.colorToPush = colors[indexColorToUse];
                    GameTapTapManager.numberOfTheButtonsWithTheRigthColor = numToCompare;

                }
                else if (modeTheGame == VisualLevelsManager.Modes.MemoryMode)
                {
                    messageToSpawn.GetComponentInChildren<Text>().text = GameTapTapManager.timeBeforeNumbersDissaper.ToString();
                }
                GameObject.Instantiate(messageToSpawn, positionForSpawnMessage.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            }
        }
    }

    public bool SpawnButton(int index)
    {
        if(modeTheGame == VisualLevelsManager.Modes.ColorMode)
        {
            buttonToSpawn.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            buttonToSpawn.GetComponentInChildren<Text>().text = GameTapTapManager.numbersForThebuttons[index];
        }
        buttons[index] = GameObject.Instantiate(buttonToSpawn, buttonPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        GameTapTapManager.buttonsInTheGame.Add(buttons[index]);
        DoubleTap doubleTap = buttons[index].GetComponent<DoubleTap>();
        doubleTap.SetNumber(index + 1);
        if (modeTheGame == VisualLevelsManager.Modes.ColorMode)
        {
            int colorNumbers = Random.Range(0, (colors.Length - 1));
            doubleTap.SetColor(colors[colorNumbers]);
            colorsNumbers[colorNumbers]++;
        }
    
        return true;
    }

    public void DefineButtonPosition()
    {
        int indexPosition = Random.Range(0, positionsToSpawn.ToArray().Length - 1);
        buttonPosition = (positionsToSpawn[indexPosition].transform.position);
        positionsToSpawn.RemoveAt(indexPosition);
    }

    public void StartTheTapTapGame()
    {
        if (tapOneTimeStart)
        {
            if (GameTapTapManager.actualNumber - 1 == GameTapTapManager.numberOfButtonsToSpawn && (modeTheGame == VisualLevelsManager.Modes.ClassicMode || modeTheGame == VisualLevelsManager.Modes.MoveNumbersMode || modeTheGame == VisualLevelsManager.Modes.MemoryMode))
            {
                winCondition = true;
            }
            else if (GameTapTapManager.actualNumber == 0 && !GameTapTapManager.gameIsOver && modeTheGame == VisualLevelsManager.Modes.ReverseMode)
            {
                winCondition = true;
            }
            else if (GameTapTapManager.actualNumber - 1 == GameTapTapManager.numberOfButtonsToSpawn && modeTheGame == VisualLevelsManager.Modes.OnlyPairsMode)
            {
                winCondition = true;
            }
            else if (GameTapTapManager.numberOfTheButtonsWithTheRigthColor <= 0 && modeTheGame == VisualLevelsManager.Modes.ColorMode)
            {
                winCondition = true;
            }
            else
            {
                winCondition = false;
            }
            if (winCondition)
            { 
                GameTapTapManager.gameIsComplete = true;
                GameCleaner();
                gameCompleteMessage.SetActive(true);
                Debug.Log("Complete");
                switch (modeTheGame)
                {
                    case VisualLevelsManager.Modes.ClassicMode:
                        if(GameTapTapManager.levelToUnlock < (LockLevelsManager.isClassicLevelLock.Length))
                        {
                            LockLevelsManager.isClassicLevelLock[GameTapTapManager.levelToUnlock] = false;
                        }
                        else
                        {
                            LockLevelsManager.isReverseLevelLock[0] = false;
                        }  
                        break;
                    case VisualLevelsManager.Modes.ReverseMode:
                        if (GameTapTapManager.levelToUnlock < (LockLevelsManager.isReverseLevelLock.Length))
                        {
                            LockLevelsManager.isReverseLevelLock[GameTapTapManager.levelToUnlock] = false;
                        }
                        else
                        {
                            LockLevelsManager.isOnlyPairsLevelLock[0] = false;
                        }
                        break;
                    case VisualLevelsManager.Modes.OnlyPairsMode:
                        if (GameTapTapManager.levelToUnlock < (LockLevelsManager.isOnlyPairsLevelLock.Length))
                        {
                            LockLevelsManager.isOnlyPairsLevelLock[GameTapTapManager.levelToUnlock] = false;
                        }
                        else
                        {
                            LockLevelsManager.isColorLevelLock[0] = false;
                        }
                        break;
                    case VisualLevelsManager.Modes.ColorMode:
                        if (GameTapTapManager.levelToUnlock < (LockLevelsManager.isColorLevelLock.Length))
                        {
                            LockLevelsManager.isColorLevelLock[GameTapTapManager.levelToUnlock] = false;
                        }
                        else
                        {
                            LockLevelsManager.isMoveNumbersLevelLock[0] = false;
                        }
                        break;
                    case VisualLevelsManager.Modes.MoveNumbersMode:
                        if (GameTapTapManager.levelToUnlock < (LockLevelsManager.isMoveNumbersLevelLock.Length))
                        {
                            LockLevelsManager.isMoveNumbersLevelLock[GameTapTapManager.levelToUnlock] = false;
                        }
                        else
                        {
                            LockLevelsManager.isMemoryLevelLock[0] = false;
                        }
                        break;
                    case VisualLevelsManager.Modes.MemoryMode:
                        if (GameTapTapManager.levelToUnlock < (LockLevelsManager.isMemoryLevelLock.Length))
                        {
                            LockLevelsManager.isMemoryLevelLock[GameTapTapManager.levelToUnlock] = false;
                        }
                        else
                        {
                            Debug.Log("CampaignIsOver");
                        }
                        break;
                }
            }
            else
            {
                GameTapTapManager.gameIsStarted = true;
            }
            tapOneTimeStart = false;
        }
        else
        {
            tapOneTimeStart = true;
        }

    }

    public void GameOverDoubleTap()
    {
        GameCleaner();
        gameOverMessageByDoubleTap.SetActive(true);
        GameTapTapManager.gameIsOver = true;
    }

    public void GameOverTapAnotherButton()
    {
        GameCleaner();
        gameOverMessageAnotherButton.SetActive(true);
        GameTapTapManager.gameIsOver = true;
    }

    public void GameOverByNumber()
    {
        GameCleaner();
        gameOverByNumberMessage.SetActive(true);
        GameTapTapManager.gameIsOver = true;
    }

    public void RestartGame(string levelName)
    {
        GameTapTapManager.gameIsOver = false;
        GameTapTapManager.gameIsComplete = false;
        SceneManager.LoadScene(levelName);
    }

    public void ResetGameProperties()
    {
        GameTapTapManager.gameIsOver = false;
        GameTapTapManager.gameIsComplete = false;
        GameCleaner();
    }

    private void GameCleaner()
    {
        foreach (GameObject s in buttons)
        {
            if (s != null)
            {
                Destroy(s);
            }
        }

        GameTapTapManager.gameIsStarted = false;
        GameTapTapManager.actualNumber = 0;
        GameTapTapManager.timeToTapAnotherButton = GameTapTapManager.originalTimeToTapAnotherButton;
        GameTapTapManager.timeToTapMakeDoubleTap = GameTapTapManager.originaltimeToTapMakeDoubleTap;
    }

}



//USE IT IF WE NEED TO SHOW BY BOOL
//[CustomEditor(typeof(StartAndEndGameManager))]
//public class MyEditor : Editor
//{
//    SerializedProperty isColorUse;
//    SerializedProperty color;
//    SerializedProperty modesGame;
//    SerializedProperty gameOverNumberMessage;
//    SerializedProperty gameOverAnotherButton;
//    SerializedProperty gameOverMessageDoubleTap;
//    SerializedProperty gameCompleteMessage;
//    SerializedProperty positionsSpawn;
//    SerializedProperty buttonSpawn;

//    private void OnEnable()
//    {
//        isColorUse = serializedObject.FindProperty("isColorMode");
//        color = serializedObject.FindProperty("colorToPush");
//        modesGame = serializedObject.FindProperty("modeTheGame");
//        gameOverNumberMessage = serializedObject.FindProperty("gameOverByNumberMessage");
//        gameOverAnotherButton = serializedObject.FindProperty("gameOverMessageAnotherButton");
//        gameOverMessageDoubleTap = serializedObject.FindProperty("gameOverMessageByDoubleTap");
//        gameCompleteMessage = serializedObject.FindProperty("gameCompleteMessage");
//        positionsSpawn = serializedObject.FindProperty("positionsToSpawn");
//        buttonSpawn = serializedObject.FindProperty("buttonToSpawn");
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        EditorGUILayout.PropertyField(modesGame);
//        EditorGUILayout.PropertyField(gameOverNumberMessage);
//        EditorGUILayout.PropertyField(gameOverAnotherButton);
//        EditorGUILayout.PropertyField(gameOverMessageDoubleTap);
//        EditorGUILayout.PropertyField(gameCompleteMessage);
//        EditorGUILayout.PropertyField(positionsSpawn);
//        EditorGUILayout.PropertyField(buttonSpawn);
//        EditorGUILayout.PropertyField(isColorUse);

//        if (isColorUse.boolValue)
//        {
//            EditorGUILayout.PropertyField(color);
//        }

//        serializedObject.ApplyModifiedProperties();
//    }
//}
