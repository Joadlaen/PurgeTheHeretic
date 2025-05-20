using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.SceneManagement;

public class HomeSquadScript : MonoBehaviour, IPointerDownHandler
{
    public Vector2 homeSquadMovement; // Store movement input

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
        homeSquadMovement.x = mainScript.homeSquadPos.x;
        homeSquadMovement.y = mainScript.homeSquadPos.y;
    }





    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Home")
        {
            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement" && ! movedPiece)
            {
                moveDirectionGenerate();
                moverScript.UpdateNameToMove("HomeSquad");
                Debug.Log(homeSquadMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting" && ! shotPiece)
            {
                shootDirectionGenerate();
                shooterScript.nameShooting = "HomeSquad";
            }
        }
    }

    public void moveDirectionGenerate()
    {
        for (int x = -1; x < 2; x+= 2)
        {
            for (int y = 1; y <= MOVEMENT; y++)
            {
                Vector2 position1 = new Vector2(homeSquadMovement.x + (y*x*SPACING) - centeringVariable, homeSquadMovement.y);
                Vector2 position2 = new Vector2(homeSquadMovement.x, homeSquadMovement.y + (y*x * SPACING) - centeringVariable);
                if (position1.x >= 0 - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position1, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeSquad");
                }
                if (position2.y >= 0 - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position2, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeSquad");
                }
            }
        }
        //Vector2 MoveNorth = new Vector2(homeSquadMovement.x, homeSquadMovement.y + 1);
        //if (MoveNorth.y < mainScript.ROWS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveNorth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeSquad");
        //}
        //Vector2 MoveSouth = new Vector2(homeSquadMovement.x, homeSquadMovement.y - 1);
        //if (MoveSouth.y >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveSouth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeSquad");
        //}
        //Vector2 MoveEast = new Vector2(homeSquadMovement.x + 1, homeSquadMovement.y);
        //if (MoveEast.x < mainScript.COLUMNS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveEast, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeSquad");
        //}
        //Vector2 MoveWest = new Vector2(homeSquadMovement.x - 1, homeSquadMovement.y);
        //if (MoveWest.x >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveWest, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeSquad");
        //}
    }
    public void UpdateHomeSquadPosition(Vector2 newPosition)
    {
        Debug.Log("tank pos update");
        homeSquadMovement = newPosition;
        Instantiate(MovedTint, newPosition, Quaternion.identity);
        movedPiece = true;
        if (newPosition.x == mainspring.enemyObjectiveCol && newPosition.y == mainspring.enemyObjectiveCol)
        {
            SceneManager.LoadScene("EnemyWins");
        }
    }
    public void shootDirectionGenerate()
    {
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y < RANGE; y++)
            {
                Vector2 position1 = new Vector2(homeSquadMovement.x + (y * x * SPACING) - centeringVariable, homeSquadMovement.y);
                Vector2 position2 = new Vector2(homeSquadMovement.x, homeSquadMovement.y + (y * x * SPACING) - centeringVariable);
                if (position1.x >= 0 - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position1, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("HomeSquad");
                }
                if (position2.y >= 0 - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position2, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("HomeSquad");
                }
            }
        }
    }
}
public class HomeSquadStats : Stats
{
    public void Initialize(string pieceName)
    {
        this.pieceName = pieceName;
        attacks = 12;
        accuracy = 3;
        wounding = 5;
        damage = 1;
        wounds = 6;
    }
}
