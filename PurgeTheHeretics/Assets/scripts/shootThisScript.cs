using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootThisScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject homeTank;
    public GameObject enemyTank;
    public GameObject homeSquad;
    public GameObject enemySquad;
    public GameObject shootPos;

    public string nameShooting = "";
    public Camera mainCamera;



    public void UpdateNameShooting(string name)
    {
        nameShooting = name;
    }
    //shows where the guns should be firing at
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 targetPosition = new Vector2(transform.position.x, transform.position.y);

    }





    public void ShootAtThings()
    {

    }
        

    

    public void Cleanup()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ShootTint");

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
