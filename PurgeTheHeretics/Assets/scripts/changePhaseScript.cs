using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class changePhaseScript : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI turnIndicate;
    public TextMeshProUGUI phaseIndicate;
    public main mainScript;
    public moveHereScript moveHereScript;
    public shootThisScript shootThisScript;
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
        Debug.Log(mainScript.CurrentPhase);
        Debug.Log(mainScript.Turn);
        turnIndicate.text = mainScript.Turn;
        phaseIndicate.text = mainScript.CurrentPhase;
        moveHereScript.Cleanup();
        shootThisScript.Cleanup();
    }
}
