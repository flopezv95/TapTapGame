using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLevelsManager : MonoBehaviour
{
    public static bool[] isClassicLevelLock = { false, true, true, true, true, true, true, true,true };
    public static bool[] isReverseLevelLock = { true, true, true, true, true, true, true, true, true };
    public static bool[] isOnlyPairsLevelLock = { true, true, true, true, true, true, true, true, true };
    public static bool[] isColorLevelLock = { true, true, true, true, true, true, true, true, true };
    public static bool[] isMoveNumbersLevelLock = { true, true, true, true, true, true, true, true, false };
    public static bool[] isMemoryLevelLock = { true, true, true, true, true, true, true, true, true };
}
