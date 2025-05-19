using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public string tagToRemove = "";

    Vector2 newPos = new Vector2();
    //shows where the object should move
    void Start()
    {
        Debug.Log(nameToMove);
    }

    public void UpdateNameToMove(string name)
    {
        nameToMove = name;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        newPos = mainCamera.ScreenToWorldPoint(eventData.position);
        newPos = new Vector2 (Mathf.Floor(newPos.x), Mathf.Floor(newPos.y));

        Debug.Log("Clicked position: " + newPos.x + ", " + newPos.y);
        Debug.Log(nameToMove);
        if (nameToMove == "HomeTank")
        {
            tagToRemove = "HomeTank";
            MoveSprite(homeTank);
            homeTankScript.UpdateHomeTankPosition(newPos);
        }
        if (nameToMove == "HomeSquad")
        {
            tagToRemove = "HomeSquad";
            MoveSprite(homeSquad);
            homeSquadScript.UpdateHomeSquadPosition(newPos);
        }
        if (nameToMove == "EnSquad")
        {
            tagToRemove = "EnSquad";
            MoveSprite(enemySquad);
            enemySquadScript.UpdateEnemySquadPosition(newPos);
        }
        if (nameToMove == "EnTank")
        {
            tagToRemove = "EnTank";
            MoveSprite(enemyTank);
            enemyTankScript.UpdateEnemyTankPosition(newPos);
        }
        Debug.Log("tag set to " + tagToRemove);
    }

    private void MoveSprite(GameObject ObjectToMove)
    {
        //RemoveOriginal();
        Debug.Log(ObjectToMove.name);
        Teleport(ObjectToMove, newPos, Quaternion.identity);

        Cleanup();
    }
    private void RemoveOriginal()
    {
        Debug.Log("in RemoveOriginal" + tagToRemove);
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToRemove);

        // Loop through each object with the specified tag
        foreach (GameObject obj in objectsWithTag)
        {
            // Convert the object's world position to the camera's viewport position
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(obj.transform.position);

            // Check if the object is within the camera's viewport
            if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1 && viewportPosition.z > 0)
            {
                // Destroy the object if it is within the camera's view
                Destroy(obj);
            }
        }
    }
    private void Teleport(GameObject ObjectToMove, Vector2 targetPosition, Quaternion rotation)
    {
        Debug.Log(ObjectToMove.name + targetPosition.ToString() + rotation.ToString());
        ObjectToMove.transform.position = targetPosition;
        ObjectToMove.transform.rotation = rotation;
    }

    public void Cleanup()
    {
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("MoveTint");

        // Loop through each object with the specified tag
        foreach (GameObject obj in objectsWithTag)
        {
            // Convert the object's world position to the camera's viewport position
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(obj.transform.position);

            // Check if the object is within the camera's viewport
            if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1 && viewportPosition.z > 0)
            {
                // Destroy the object if it is within the camera's view
                Destroy(obj);
            }
        }
    }

    

}
