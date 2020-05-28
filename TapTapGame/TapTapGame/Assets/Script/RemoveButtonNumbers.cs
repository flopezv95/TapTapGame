using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveButtonNumbers : MonoBehaviour
{

    private RemoveButtonNumbers removeButtonNumbers;

    public void CallThePersistenObjectForTheRemoveFuntion()
    {
        removeButtonNumbers = GameObject.FindGameObjectWithTag("Background").GetComponent<RemoveButtonNumbers>();
        removeButtonNumbers.RemoveNumbers();
    }
   public void RemoveNumbers()
    {
        StartCoroutine("CallTheRemoveFunction");
    }

    IEnumerator CallTheRemoveFunction()
    {
        
        yield return new WaitForSeconds(GameTapTapManager.timeBeforeNumbersDissaper);
        RemoveTheButtonNumbers();
    }

    private void RemoveTheButtonNumbers()
    {
        foreach(GameObject actualButton in GameTapTapManager.buttonsInTheGame)
        {
            actualButton.GetComponentInChildren<Text>().text = "";
        }
    }
}
