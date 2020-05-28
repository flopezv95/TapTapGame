using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLevelsManager : MonoBehaviour
{
    [System.Serializable]
    public struct LevelsVisualStructure
    {
        public GameObject levelLock;
    }

    [System.Serializable]
    public enum Modes
    {
        ClassicMode,
        ReverseMode,
        OnlyPairsMode,
        ColorMode,
        MoveNumbersMode,
        MemoryMode,
    }

    public Modes gameModes;
    public LevelsVisualStructure[] levelsOfTheMode;

    void Start()
    {
        switch(gameModes)
        {
            case Modes.ClassicMode:
                for (int i = 0; i < levelsOfTheMode.Length; i++)
                {
                    levelsOfTheMode[i].levelLock.SetActive(LockLevelsManager.isClassicLevelLock[i]);
                }
                break;
            case Modes.ReverseMode:
                for (int i = 0; i < levelsOfTheMode.Length; i++)
                {
                    levelsOfTheMode[i].levelLock.SetActive(LockLevelsManager.isReverseLevelLock[i]);
                }
                break;
            case Modes.OnlyPairsMode:
                for (int i = 0; i < levelsOfTheMode.Length; i++)
                {
                    levelsOfTheMode[i].levelLock.SetActive(LockLevelsManager.isOnlyPairsLevelLock[i]);
                }
                break;
            case Modes.ColorMode:
                for (int i = 0; i < levelsOfTheMode.Length; i++)
                {
                    levelsOfTheMode[i].levelLock.SetActive(LockLevelsManager.isColorLevelLock[i]);
                }
                break;
            case Modes.MoveNumbersMode:
                for (int i = 0; i < levelsOfTheMode.Length; i++)
                {
                    levelsOfTheMode[i].levelLock.SetActive(LockLevelsManager.isMoveNumbersLevelLock[i]);
                }
                break;
            case Modes.MemoryMode:
                for (int i = 0; i < levelsOfTheMode.Length; i++)
                {
                    levelsOfTheMode[i].levelLock.SetActive(LockLevelsManager.isMemoryLevelLock[i]);
                }
                break;
        }
    }

}
