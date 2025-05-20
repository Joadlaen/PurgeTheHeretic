using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class turnPassScript : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI turnIndicate;
    public TextMeshProUGUI phaseIndicate;
    public main mainScript;
    public changePhaseScript changePhaseScript;
    public EnemySquadScript enemySquadScript;
    public EnemyTankScript enemyTankScript;
    public HomeTankScript homeTankScript;
    public HomeSquadScript homeSquadScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        homeSquadScript.movedPiece = false;
        homeTankScript.movedPiece = false;
        enemyTankScript.movedPiece = false;
        enemySquadScript.movedPiece = false;
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
        turnIndicate.text = mainScript.Turn;
        phaseIndicate.text = mainScript.CurrentPhase;
    }

}
