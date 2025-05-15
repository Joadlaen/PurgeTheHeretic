using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveHereScript : MonoBehaviour, IPointerDownHandler
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
    public Camera mainCamera;

    public string nameToMove = "";
    public string tagToRemove = "MoveTint";

    Vector2 newPos = new Vector2();
    //shows where the object should move
    public void OnPointerDown(PointerEventData eventData)
    {
        newPos = mainCamera.ScreenToWorldPoint(eventData.position);
        newPos = new Vector2 (newPos.x, newPos.y);

        Debug.Log("Clicked position: " + newPos.x + ", " + newPos.y);
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

        Destroy(ObjectToMove);
        Instantiate(ObjectToMove, newPos, Quaternion.identity);
        Cleanup();
    }

    public void Cleanup()
    {
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToRemove);

        // Loop through each object with the specified tag
        foreach (GameObject obj in objectsWithTag)
        {
            // Convert the object's world position to the camera's viewport position
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(obj.transform.position);

            // Check if the object is within the camera's viewport
            if (viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
                viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
                viewportPosition.z > 0)  // Check if the object is in front of the camera
            {
                // Destroy the object if it is within the camera's view
                Destroy(obj);
            }
        }
    }

    

}
