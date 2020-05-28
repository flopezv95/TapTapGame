using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTapTapManager : MonoBehaviour
{
    static public int maxButtonsInTheScreen = 20;
    static public int numberOfButtonsToSpawn = 5;
    static public List<GameObject> buttonsInTheGame = new List<GameObject>();
    static public int levelToUnlock = 0;
    static public string[] numbersForThebuttons = {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16", "17", "18", "19", "20" };
    static public bool gameIsStarted = false;
    static public bool gameIsOver = false;
    static public bool gameIsComplete = false;
    static public int actualNumber = 0;
    static public float timeToTapMakeDoubleTap = 0.5f;
    static public float originaltimeToTapMakeDoubleTap = 0.5f;
    static public float timeToTapAnotherButton = 2.0f;
    static public float originalTimeToTapAnotherButton = 2.0f;
    static public int numberOfTheButtonsWithTheRigthColor = 0;
    static public Color colorToPush;
    static public float timeBeforeNumbersDissaper = 1;
}
