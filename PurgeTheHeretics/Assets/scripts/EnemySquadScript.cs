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
    public GameObject MovedTint;
    public bool movedPiece = false;
    public bool shotPiece = false;

    public main mainScript;
    public moveHereScript moverScript;
    public shootThisScript shooterScript;

    const int RANGE = 6;
    const int MOVEMENT = 1;
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
            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement" && ! movedPiece)
            {
                moveDirectionGenerate();
                moverScript.UpdateNameToMove("EnSquad");
                Debug.Log(enemySquadMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting" && ! shotPiece)
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
                if (position1.x < mainScript.ROWS - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position1, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("EnSquad");
                }
                if (position2.y < mainScript.COLUMNS - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position2, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("EnSquad");
                }
            }
        }
        //Vector2 MoveNorth = new Vector2(enemySquadMovement.x, enemySquadMovement.y + 1);
        //if (MoveNorth.y < mainScript.ROWS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveNorth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnSquad");
        //}
        //Vector2 MoveSouth = new Vector2(enemySquadMovement.x, enemySquadMovement.y - 1);
        //if (MoveSouth.y >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveSouth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnSquad");
        //}
        //Vector2 MoveEast = new Vector2(enemySquadMovement.x + 1, enemySquadMovement.y);
        //if (MoveEast.x < mainScript.COLUMNS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveEast, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnSquad");
        //}
        //Vector2 MoveWest = new Vector2(enemySquadMovement.x - 1, enemySquadMovement.y);
        //if (MoveWest.x >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveWest, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnSquad");
        //}
    }
    public void UpdateEnemySquadPosition(Vector2 newPosition)
    {
        Debug.Log("tank pos update");
        enemySquadMovement = newPosition;
        Instantiate(MovedTint, newPosition, Quaternion.identity);
        movedPiece = true;
    }
    public void shootDirectionGenerate()
    {
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y < RANGE; y++)
            {
                Vector2 position1 = new Vector2(enemySquadMovement.x + (y * x * SPACING) - centeringVariable, enemySquadMovement.y);
                Vector2 position2 = new Vector2(enemySquadMovement.x, enemySquadMovement.y + (y * x * SPACING) - centeringVariable);
                if (position1.x < mainScript.ROWS - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position1, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("EnSquad");
                }
                if (position2.y < mainScript.COLUMNS - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position2, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("EnSquad");
                }
            }
        }
    }
}
public class EnemySquadStats : Stats
{
    
}


