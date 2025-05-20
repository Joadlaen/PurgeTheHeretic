using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.SceneManagement;

public class HomeTankScript : MonoBehaviour, IPointerDownHandler
{

    public Vector3 homeTankMovement; // Store movement input

    //declaring all GameObjects involved with the movement, shooting and win conditions.

    //System.Random D6 = new System.Random(); i originally wanted a 4 or higher on a random number generator to allow and extra square of travel but never managed it
    public GameObject moveTint;
    public GameObject shootTint;
    public GameObject enemySquad;
    public GameObject MovedTint;
    //indicators for when the piece has been shot, they are reset externally in most cases such as by the phase changer
    public bool movedPiece = false;
    public bool shotPiece = false;
    //certain variables are from other scripts and the scripts need to be declared and assigned
    //holds constants, variables and structs from main
    public main mainScript;
    // gives a new position in the vector2/3 and allows data to be passed to and from
    public moveHereScript moverScript;
    public shootThisScript shooterScript;

    //constants that could be declared in the main script and inheriterd to a subclass in this one
    const int RANGE = 10;
    const int MOVEMENT = 2;
    const int SPACING = 1;

    //assigns the vector struct and initialises the hometankstats subclass
    public void Start()
    {
        if (mainScript == null)
        {
            Debug.Log("not being assigned");
        }
        homeTankMovement = mainScript.homeTankPos;
        HomeTankStats stats = GetComponent<HomeTankStats>();
        stats.Initialize("HomeTank");        
    }



    //looks for a pointerdown event and runs a function when the listener detects one
    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Home")
        {
            Debug.Log("HomeTank");
            //checks if a given piece can be moved
            if (mainScript.CurrentPhase == "Movement" && ! movedPiece)
            {
                //activates and updates the respective functions required to move the piece
                moveDirectionGenerate();
                moverScript.UpdateNameToMove("HomeTank");
            }
            if (mainScript.CurrentPhase == "Shooting" && ! shotPiece)
            {
                //would have done the same for shooting but the function didn't work well enough for the given time
                //
                Debug.Log("this feature is not currently available");
                //movedPiece = false;
                //shootDirectionGenerate();
                //shooterScript.nameShooting = "HomeTank";
            }
        }
    }

    public void moveDirectionGenerate()
    {


        //foreach (var item in transform)
        //{
        //    Destroy(item);
        //}
        // creates a plus shape of movement indicator using two nested for loops
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y <= MOVEMENT; y++)
            {
                Vector2 position1 = new Vector2(homeTankMovement.x + (y * x * SPACING), homeTankMovement.y);
                Vector2 position2 = new Vector2(homeTankMovement.x, homeTankMovement.y + (y * x * SPACING));
                if (position1.x < mainScript.ROWS - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position1, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeTank");
                }
                if (position2.y < mainScript.COLUMNS - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position2, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeTank");
                }
            }
        }
        //Vector2 MoveNorth = new Vector2(homeTankMovement.x, homeTankMovement.y + 1);
        //if (MoveNorth.y < mainScript.ROWS) 
        //{
        //    GameObject move = Instantiate(moveTint, MoveNorth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeTank");
        //}
        //Vector2 MoveSouth = new Vector2(homeTankMovement.x, homeTankMovement.y - 1);
        //if (MoveSouth.y >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveSouth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeTank");
        //}
        //Vector2 MoveEast = new Vector2(homeTankMovement.x + 1, homeTankMovement.y);
        //if (MoveEast.x < mainScript.COLUMNS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveEast, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeTank");
        //}
        //Vector2 MoveWest = new Vector2(homeTankMovement.x - 1, homeTankMovement.y);
        //if (MoveWest.x >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveWest, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("Home");
        //}
    }
    public void UpdateHomeTankPosition(Vector3 newPosition)
    {
        // sets the new position for future logic and calculations
        Debug.Log("tank pos update to " + newPosition);
        homeTankMovement.x = newPosition.x;
        homeTankMovement.y = newPosition.y;
        homeTankMovement.z = newPosition.z;
        Debug.Log("new tank pos " + homeTankMovement);
        // shows and logically declares that it can't be moved until otherwise stated
        Instantiate(MovedTint, newPosition, Quaternion.identity);
        movedPiece = true;
        // win condition for this piece, checks against the grid tracker in main script
        if ((newPosition.x + mainScript.centeringVariable == mainScript.enemyObjectPositionCol + 1) &&
    (newPosition.y + mainScript.centeringVariable == mainScript.enemyObjectPositionRow + 1))
        {
            Debug.Log("should endthe game");
            SceneManager.LoadScene(2);
        }
    }
    // same as move direction but it generates shoot indicators instead and is not in use until shooting script is working
    public void shootDirectionGenerate()
    {
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y < RANGE; y++)
            {
                Vector2 position1 = new Vector2(homeTankMovement.x + (y * x * SPACING), homeTankMovement.y);
                Vector2 position2 = new Vector2(homeTankMovement.x, homeTankMovement.y + (y * x * SPACING));

                if (position1.x >= 0 - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position1, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("HomeTank");
                }
                if (position2.y >= 0 - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position2, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("HomeTank");
                }
            }
        }
    }
}

// stats classis inherited to the subclass and initialised here.
// object are mostly used for shooting script but could be utilised elsewhere as well as other constants being included in the class as objects
// these are my plans for future projects
public class HomeTankStats : Stats
{
    public void Initialize(string pieceName)
    {
        this.pieceName = pieceName;
        attacks = 5;
        accuracy = 5;
        wounding = 2;
        damage = 2;
        wounds = 16;
    }
}

