using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class HomeTankScript : MonoBehaviour, IPointerDownHandler
{

    public Vector2 homeTankMovement; // Store movement input


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


    public void Start()
    {
        homeTankMovement.x = mainScript.homeTankPos.x;
        homeTankMovement.y = mainScript.homeTankPos.y;
    }




    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Home")
        {
            Debug.Log("HomeTank");
            if (mainScript.CurrentPhase == "Movement")
            {
                moveDirectionGenerate();
                moverScript.nameToMove = "HomeTank";
                Debug.Log(homeTankMovement.ToString());
            }
            if (mainScript.CurrentPhase == "Shooting")
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
            for (int y = 0; y <= MOVEMENT; y++)
            {
                Vector2 position1 = new Vector2(homeTankMovement.x + (y * x * SPACING), homeTankMovement.y);
                Vector2 position2 = new Vector2(homeTankMovement.x, homeTankMovement.y + (y * x * SPACING));
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

public class HomeTankStats : Stats
{

}
