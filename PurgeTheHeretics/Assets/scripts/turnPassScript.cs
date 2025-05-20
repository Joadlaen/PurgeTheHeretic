using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class turnPassScript : MonoBehaviour, IPointerDownHandler
{
    // declare and assign textmesh and scripts
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
        // resets the moved piece so pieces can be moved when the next turn would come around. the same would be done for shooting
        homeSquadScript.movedPiece = false;
        homeTankScript.movedPiece = false;
        enemyTankScript.movedPiece = false;
        enemySquadScript.movedPiece = false;
        // checks the current trun and switches it appropriately
        if (mainScript.CurrentPhase == "Movement")
        {
            mainScript.CurrentPhase = "Shooting";
        }
        // when the turn needs to change as well
        if (mainScript.CurrentPhase == "Shooting")
        {
            mainScript.CurrentPhase = "Movement";

            if (mainScript.Turn == "Home")
            {
                mainScript.Turn = "Enemy";
            }
            else if (mainScript.Turn == "Enemy")
            {
                mainScript.Turn = "Home";
            }
            Debug.Log(mainScript.gridTracker);
            // tells the players whose turn it is
            turnIndicate.text = mainScript.Turn;
            phaseIndicate.text = mainScript.CurrentPhase;
        }
    }

}
