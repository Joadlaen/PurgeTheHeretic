using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
// declare the scripts that contain the central variables and functions to use
    public main mainScript;
    public moveHereScript moverScript;
    public shootThisScript shooterScript;
//constants that could be added to the stats class to demonstrate inheritance.
    const int RANGE = 6;
    const int MOVEMENT = 1;
    const int SPACING = 1;
    const int centeringVariable = 0;

    public void Start()
    {
   // declares the position of the enemy squad using Vector2 
        enemySquadMovement.x = mainScript.enemySquadPos.x;
        enemySquadMovement.y = mainScript.enemySquadPos.y;
    }



// listens for a pointer down event and checks what the current turn is

    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Enemy")
        { 
// detects what phase it is and if a given piece has already done their action for that phase.

            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement" && ! movedPiece)
            {
                moveDirectionGenerate();
            // sends the moverscripg attached to thd movement indicator information about the object this script is attached to 
                moverScript.UpdateNameToMove("EnSquad");
                Debug.Log(enemySquadMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting" && ! shotPiece)
            {
            //same as the movement function but to the shooter script
                movedPiece = false;
                shootDirectionGenerate();
                shooterScript.nameShooting = "EnSquad";
            }
        }
    }

    public void moveDirectionGenerate()
    {
    // runs a nested for loop that creates a cross shape when the Instantiate functions are called
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
        // a different attempt to try and make a plus shape to easily pass information to the indicators so they can move the object this script is attached to
        // it was just as much hassle for less results as the movement constant wasn't implemented 
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
        // Centre the object to the new position for future calculations
        Debug.Log("tank pos update");
        enemySquadMovement = newPosition;
// Spawn an indicator to say, this has moved

        Instantiate(MovedTint, newPosition, Quaternion.identity);
// assign logic to say this object has moved

        movedPiece = true;
        if (newPosition.x + mainScript.centeringVariable == mainScript.homeObjectPositionCol && newPosition.y + mainScript.centeringVariable == mainScript.homeObjectPositionCol)
        {
// current function used to run the win condition. loads the win scene if this object is in the same position as the objective

            Debug.Log("should endthe game");
            SceneManager.LoadScene(3);
        }
    }
    public void shootDirectionGenerate()
    {
    //same as move direction but the logic in the script that handled it didn't work well enough
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
// inherited class would provide the shooting script with values to run the functions on.
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


