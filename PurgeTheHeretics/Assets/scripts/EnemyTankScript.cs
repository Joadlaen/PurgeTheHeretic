using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.SceneManager;

public class EnemyTankScript : MonoBehaviour, IPointerDownHandler
{

    
    public Vector2 enemyTankMovement; // Store movement input

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
    const int centeringVariable = 0;

    public void Start()
    {
        enemyTankMovement.x = mainScript.enemyTankPos.x;
        enemyTankMovement.y = mainScript.enemyTankPos.y;
    }




    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript.Turn == "Enemy")
        {
            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement" && ! movedPiece)
            {
                moveDirectionGenerate();
                moverScript.UpdateNameToMove("EnTank");
                Debug.Log(enemyTankMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting" && ! shotPiece)
            {
                movedPiece = false;
                shootDirectionGenerate();
                shooterScript.nameShooting = "EnTank";
            }
        }
    }

    public void moveDirectionGenerate()
    {

        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y <= MOVEMENT; y++)
            {
                Vector2 position1 = new Vector2(enemyTankMovement.x + (y * x * SPACING) - centeringVariable, enemyTankMovement.y);
                Vector2 position2 = new Vector2(enemyTankMovement.x, enemyTankMovement.y + (y * x * SPACING) - centeringVariable);
                if (position1.x < mainScript.ROWS - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position1, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("EnTank");
                }
                if (position2.y < mainScript.COLUMNS - mainScript.centeringVariable)
                {
                    GameObject move = Instantiate(moveTint, position2, Quaternion.identity);
                    move.GetComponent<moveHereScript>().UpdateNameToMove("EnTank");
                }
            }
        }
        //Vector2 MoveNorth = new Vector2(enemyTankMovement.x, enemyTankMovement.y + 1);
        //if (MoveNorth.y < mainScript.ROWS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveNorth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnTank");
        //}
        //Vector2 MoveSouth = new Vector2(enemyTankMovement.x, enemyTankMovement.y - 1);
        //if (MoveSouth.y >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveSouth, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnTank");
        //}
        //Vector2 MoveEast = new Vector2(enemyTankMovement.x + 1, enemyTankMovement.y);
        //if (MoveEast.x < mainScript.COLUMNS)
        //{
        //    GameObject move = Instantiate(moveTint, MoveEast, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnTank");
        //}
        //Vector2 MoveWest = new Vector2(enemyTankMovement.x - 1, enemyTankMovement.y);
        //if (MoveWest.x >= 0)
        //{
        //    GameObject move = Instantiate(moveTint, MoveWest, Quaternion.identity);
        //    move.GetComponent<moveHereScript>().UpdateNameToMove("EnTank");
        //}
    }
    public void UpdateEnemyTankPosition(Vector2 newPosition)
    {
        Debug.Log("tank pos update");
        enemyTankMovement = newPosition;
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
                Vector2 position1 = new Vector2(enemyTankMovement.x + (y * x * SPACING) - centeringVariable, enemyTankMovement.y);
                Vector2 position2 = new Vector2(enemyTankMovement.x, enemyTankMovement.y + (y * x * SPACING) - centeringVariable);
                if (position1.x < mainScript.ROWS - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position1, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("EnTank");
                }
                if (position2.y < mainScript.COLUMNS - mainScript.centeringVariable)
                {
                    GameObject shoot = Instantiate(shootTint, position2, Quaternion.identity);
                    shoot.GetComponent<shootThisScript>().UpdateNameShooting("EnTank");
                }
            }
        }
    }
}
public class EnemyTankStats : Stats
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
