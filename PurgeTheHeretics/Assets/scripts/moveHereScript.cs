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

    Vector2 newPos = new Vector2();

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

    private void MoveSprite(GameObject OnjectToMove)
    {
        Destroy(OnjectToMove);
        Instantiate(OnjectToMove, newPos, Quaternion.identity);
    }

    

}
