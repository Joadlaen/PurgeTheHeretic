using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveHereScript : MonoBehaviour
{
    public HomeTankScript homeTankScript;

    public HomeSquadScript homeSquadScript;



    public EnemyTankScript enemyTankScript;

    public EnemySquadScript enemySquadScript;
    //shows where the object should move
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 WorldPos = eventData.position;

        MoveSprite(WorldPos);
    }

    private void MoveSprite(Vector2 newPos)
    {
        if (gameObject.CompareTag("HomeSquad"))
        {
            homeSquadScript.transform.position = newPos;
        }
        else if (gameObject.CompareTag("HomeTank"))
        {
            homeTankScript.transform.position = newPos;
        }
        else if (gameObject.CompareTag("EnemySquad"))
        {
            enemySquadScript.transform.position = newPos;
        }
        else if (gameObject.CompareTag("EnemyTank"))
        {
            enemyTankScript.transform.position = newPos;
        }
    }

    

}
