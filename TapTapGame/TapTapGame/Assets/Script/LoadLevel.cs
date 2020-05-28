using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public GameObject Message;
    public VisualLevelsManager.Modes modeTheGame;

    private string levelName;

    public void LoadMainMenu(string levelNameToOpen)
    {
        SceneManager.LoadScene(levelNameToOpen);
    }

        public void LoadANewlevel(int levelToOpen)
    {
        switch (modeTheGame)
        {
            case VisualLevelsManager.Modes.ClassicMode:
                if (!LockLevelsManager.isClassicLevelLock[levelToOpen])
                {
                    SceneManager.LoadScene(levelName);
                }
                else
                {
                    ShowMessageFunction();
                }
                break;
            case VisualLevelsManager.Modes.ReverseMode:
                if (!LockLevelsManager.isReverseLevelLock[levelToOpen])
                {
                    SceneManager.LoadScene(levelName);
                }
                else
                {
                    ShowMessageFunction();
                }
                break;
            case VisualLevelsManager.Modes.OnlyPairsMode:
                if (!LockLevelsManager.isOnlyPairsLevelLock[levelToOpen])
                {
                    SceneManager.LoadScene(levelName);
                }
                else
                {
                    ShowMessageFunction();
                }
                break;
            case VisualLevelsManager.Modes.ColorMode:
                if (!LockLevelsManager.isColorLevelLock[levelToOpen])
                {
                    SceneManager.LoadScene(levelName);
                }
                else
                {
                    ShowMessageFunction();
                }
                break;
            case VisualLevelsManager.Modes.MoveNumbersMode:
                if (!LockLevelsManager.isMoveNumbersLevelLock[levelToOpen])
                {
                    SceneManager.LoadScene(levelName);
                }
                else
                {
                    ShowMessageFunction();
                }
                break;
            case VisualLevelsManager.Modes.MemoryMode:
                if (!LockLevelsManager.isMemoryLevelLock[levelToOpen])
                {
                    SceneManager.LoadScene(levelName);
                }
                else
                {
                    ShowMessageFunction();
                }
                break;
        }
    }
    public void SetLevelName(string levelNameToSet)
    {
        levelName = levelNameToSet;
    }

    private void ShowMessageFunction()
    {
        StartCoroutine("ShowMessage");
    }

    IEnumerator ShowMessage()
    {
        Message.SetActive(true);
        yield return new WaitForSeconds(2);
        Message.SetActive(false);
    }
}
