using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveHereScript : MonoBehaviour
{
    public HomeTankScript homeTankScript;
    public GameObject homeTank;

    public HomeSquadScript homeSquadScript;
    public GameObject homeSquad;



    public EnemyTankScript enemyTankScript;
    public GameObject enemyTank;

    public EnemySquadScript enemySquadScript;
    public GameObject enemySquad;

    public GameObject moveToThisPoint;

    public string nameToMove = "";
    //shows where the object should move
    public void OnPointerDown(PointerEventData eventData)
    {
        if (nameToMove == "HomeTank")
        {
            MoveSprite(homeTank);
        }
        if (nameToMove == "HomeSquad")
        {
            MoveSprite(homeSquad);
        }
        if (nameToMove == "EnSquad")
        {
            MoveSprite(enemySquad);
        }
        if (nameToMove == "EnTank")
        {
            MoveSprite(enemyTank);
        }
    }

    private void MoveSprite(GameObject ObjectToMove)
    {
        //Destroy(OnjectToMove);
        //Instantiate(OnjectToMove, newPos, Quaternion.identity);
        // Get the position of the clicked object (the object this script is attached to)
        Vector2 objectPosition = ObjectToMove.transform.position;

        // Optionally, you can use the event data position if you need the position the user clicked on
        // Vector3 objectPosition = eventData.position;

        // Now move the object to the new position
        Destroy(ObjectToMove);
        Instantiate(ObjectToMove, objectPosition, Quaternion.identity);
    }

    

}
