using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class EnemyTankScript : MonoBehaviour, IPointerDownHandler
{

    
    public Vector2 enemyTankMovement; // Store movement input

    System.Random D6 = new System.Random();
    public GameObject moveTint;
    public GameObject shootTint;
    public GameObject enemySquad;
    public bool movedPiece = false;

    public main mainScript;
    public moveHereScript moverScript;
    public shootThisScript shooterScript;

    const int RANGE = 6;
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
            if (mainScript.CurrentPhase == "Movement")
            {
                moveDirectionGenerate();
                moverScript.nameToMove = "EnTank";
                Debug.Log(enemyTankMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting")
            {
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
                Instantiate(moveTint, position1, Quaternion.identity);
                Instantiate(moveTint, position2, Quaternion.identity);
            }
        }
    }
    public void shootDirectionGenerate()
    {
        for (int x = -1; x < 2; x += 2)
        {
            for (int y = 1; y < RANGE; y++)
            {
                Vector2 position1 = new Vector2(y * x * SPACING, 0);
                Vector2 position2 = new Vector2(0, y * x * SPACING);
                Instantiate(shootTint, position1, Quaternion.identity);
                Instantiate(shootTint, position2, Quaternion.identity);
            }
        }
    }
}
public class EnemyTankStats : Stats
{

}