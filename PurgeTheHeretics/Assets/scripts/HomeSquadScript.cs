using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class HomeSquadScript : MonoBehaviour, IPointerDownHandler
{
    public Vector2 homeSquadMovement; // Store movement input

    System.Random D6 = new System.Random();
    public GameObject moveTint;
    public GameObject shootTint;
    public GameObject enemySquad;

    public main mainScript;

    const int RANGE = 6;
    const int MOVEMENT = 2;
    const int SPACING = 1;
    const int centeringVariable = 0;




    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Home")
        {
            int Advancer = D6.Next(1, 7);
            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement")
            {
                moveDirectionGenerate();
            }
            if (mainScript.CurrentPhase == "Shooting")
            {
                shootDirectionGenerate();
            }
        }
    }

    public void moveDirectionGenerate()
    {
        for (int x = -1; x < 2; x+= 2)
        {
            for (int y = 1; y < MOVEMENT; y++)
            {
                Vector2 position1 = new Vector2(homeSquadMovement.x + (y*x*SPACING) - centeringVariable, homeSquadMovement.y);
                Vector2 position2 = new Vector2(homeSquadMovement.x, homeSquadMovement.y + (y*x * SPACING) - centeringVariable);
                Instantiate(moveTint, position1, Quaternion.identity);
                Instantiate(moveTint, position2, Quaternion.identity);
            }
        }
    }
    public void shootDirectionGenerate()
    {

    }
}
public class HomeSquadStats : Stats
{

}
