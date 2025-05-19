using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class turnPassScript : MonoBehaviour, IPointerDownHandler
{
    public main mainScript;
    public changePhaseScript changePhaseScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        changePhaseScript.RestOfIt();

        if (mainScript.Turn == "Home")
        {
            mainScript.Turn = "Enemy";
        }
        else if (mainScript.Turn == "Enemy")
        {
            mainScript.Turn = "Home";
        }
        Debug.Log(mainScript.gridTracker);

        if (mainScript.CurrentPhase == "Shooting")
        {
            mainScript.CurrentPhase = "Movement";
        }
    }

}
