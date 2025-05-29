using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class changePhaseScript : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI turnIndicate;
    public TextMeshProUGUI phaseIndicate;
    public main mainScript;
    public Camera mainCamera;
    public moveHereScript moveHereScript;
    public shootThisScript shootThisScript;
    public EnemySquadScript enemySquadScript;
    public EnemyTankScript enemyTankScript;
    public HomeTankScript homeTankScript;
    public HomeSquadScript homeSquadScript;

    void Awake()
    {
        turnIndicate.text = mainScript.Turn;
        phaseIndicate.text = mainScript.CurrentPhase;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        homeSquadScript.movedPiece = false;
        homeTankScript.movedPiece = false;
        enemyTankScript.movedPiece = false;
        enemySquadScript.movedPiece = false;

        Debug.Log(mainScript.CurrentPhase);
        Debug.Log(mainScript.Turn);
        Debug.Log(mainScript.CurrentPhase);

        if (mainScript.CurrentPhase == "Movement")
        {
            //mainScript.CurrentPhase = "Shooting";
            Debug.Log("it's always " + mainScript.CurrentPhase);
        }

        //until shooting is working, this will not be possible to activate
        else if (mainScript.CurrentPhase == "Shooting")
        {
            if (mainScript.Turn == "Home")
            {
                mainScript.Turn = "Enemy";
                mainScript.CurrentPhase = "Movement";
            }
            else if (mainScript.Turn == "Enemy")
            {
                mainScript.Turn = "Home";
                mainScript.CurrentPhase = "Movement";
            }
        }

        Debug.Log(mainScript.CurrentPhase);
        Debug.Log(mainScript.Turn);

        turnIndicate.text = mainScript.Turn;
        phaseIndicate.text = mainScript.CurrentPhase;

        MoveCleanup();
        ShootCleanup();
        RemoveAll();
    }
    private void MoveCleanup()
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
    private void ShootCleanup()
    {
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ShootTint");

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

    private void RemoveAll()
    {
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("MovedTint");

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
