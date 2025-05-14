using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemySquadScript : MonoBehaviour, IPointerDownHandler
{
    public Vector2 enemySquadMovement; // Store movement input
    System.Random D6 = new System.Random();
    public GameObject moveTint;
    public GameObject shootTint;
    public GameObject enemySquad;

    public main mainScript;
    public moveHereScript moverScript;
    public shootThisScript shooterScript;

    const int RANGE = 6;
    const int MOVEMENT = 2;
    const int SPACING = 1;
    const int centeringVariable = 0;

    public void Start()
    {
        enemySquadMovement.x = mainScript.enemySquadPos.x;
        enemySquadMovement.y = mainScript.enemySquadPos.y;
    }





    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Enemy")
        {
            int Advancer = D6.Next(1, 7);
            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement")
            {
                moveDirectionGenerate();
                moverScript.nameToMove = "EnSquad";
            }
            if (mainScript.CurrentPhase == "Shooting")
            {
                shootDirectionGenerate();
                shooterScript.nameShooting = "EnSquad";
            }
        }
    }

    public void moveDirectionGenerate()
    {
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y <= MOVEMENT; y++)
            {
                Vector2 position1 = new Vector2(enemySquadMovement.x + (y * x * SPACING) - centeringVariable, enemySquadMovement.y);
                Vector2 position2 = new Vector2(enemySquadMovement.x, enemySquadMovement.y + (y * x * SPACING) - centeringVariable);
                Instantiate(moveTint, position1, Quaternion.identity);
                Instantiate(moveTint, position2, Quaternion.identity);
            }
        }
    }
    public void shootDirectionGenerate()
    {

    }
}
public class EnemySquadStats : Stats
{
    
}


