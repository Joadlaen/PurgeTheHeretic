using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class HomeTankScript : MonoBehaviour, IPointerDownHandler
{

    public Vector3 homeTankMovement; // Store movement input


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

    const int RANGE = 10;
    const int MOVEMENT = 2;
    const int SPACING = 1;


    public void Start()
    {
        homeTankMovement = mainScript.homeTankPos;
        HomeTankStats stats = GetComponent<HomeTankStats>();
        stats.Initialize("HomeTank");        
    }




    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Home")
        {
            Debug.Log("HomeTank");
            if (mainScript.CurrentPhase == "Movement" && ! movedPiece)
            {
                moveDirectionGenerate();
                moverScript.UpdateNameToMove("HomeTank");
                Debug.Log(homeTankMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting" && ! shotPiece)
            {
                shootDirectionGenerate();
                shooterScript.nameShooting = "HomeTank";
            }
        }
    }

    public void moveDirectionGenerate()
    {


        //foreach (var item in transform)
        //{
        //    Destroy(item);
        //}
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y <= MOVEMENT; y++)
            {
                Vector3 position1 = new Vector3(homeTankMovement.x + (y * x * SPACING), homeTankMovement.y, homeTankMovement.z);
                Vector3 position2 = new Vector3(homeTankMovement.x, homeTankMovement.y + (y * x * SPACING), homeTankMovement.z);
        
                if (position1.x >= 0 - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position1, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("HomeTank");
                }
                if (position2.y >= 0 - mainScript.centeringVariable)
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
        Debug.Log("tank pos update to " + newPosition);
        homeTankMovement.x = newPosition.x;
        homeTankMovement.y = newPosition.y;
        homeTankMovement.z = newPosition.z;
        Debug.Log("new tank pos " + homeTankMovement);
        Instantiate(MovedTint, newPosition, Quaternion.identity);
        movedPiece = true;
    }

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

