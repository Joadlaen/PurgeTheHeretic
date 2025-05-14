using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class changePhaseScript : MonoBehaviour
{
    public main mainScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(mainScript.CurrentPhase);
        if (mainScript.CurrentPhase == "movement")
        {
            mainScript.CurrentPhase = "shooting";
            Debug.Log(mainScript.CurrentPhase);
        }
        else if (mainScript.CurrentPhase == "shooting")
        {
            if (mainScript.Turn == "Home")
            {
                mainScript.Turn = "Enemy";
                mainScript.CurrentPhase = "movement";
            }
            else if (mainScript.Turn == "Enemy")
            {
                mainScript.Turn = "Home";
                mainScript.CurrentPhase = "movement";
            }
        }
    }
}
