using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevelSettings : MonoBehaviour
{
    public void SetNumberOfButtons(int ButtonsToSpawn)
    {
        GameTapTapManager.numberOfButtonsToSpawn = ButtonsToSpawn;
    }

    public void SetTimeToDoubleTap(float timeToMakeDoubleTap)
    {
        GameTapTapManager.timeToTapMakeDoubleTap = timeToMakeDoubleTap;
        GameTapTapManager.originaltimeToTapMakeDoubleTap = timeToMakeDoubleTap;

    }

    public void SetTimeToTapOtherButton(float timeTapAnotherButton)
    {
        GameTapTapManager.timeToTapAnotherButton = timeTapAnotherButton;
        GameTapTapManager.originalTimeToTapAnotherButton = timeTapAnotherButton;
    }

    public void SetLevelToUnlock(int levelToUnlock)
    {
        GameTapTapManager.levelToUnlock = levelToUnlock;
    }

    public void SetTimeBeforeNumbersDissapear(float time)
    {
        GameTapTapManager.timeBeforeNumbersDissaper = time;
    }
}
