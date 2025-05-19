using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class remover : MonoBehaviour, IPointerDownHandler
{
    public Camera mainCamera;
    public void OnPointerDown(PointerEventData eventData)
    {
        // Find all GameObjects with the specified tag
        GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag("MoveTint");
        GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("ShootTint");
        GameObject[] objectsWithTag3 = GameObject.FindGameObjectsWithTag("MovedTint");

        // Loop through each object with the specified tag
        foreach (GameObject obj in objectsWithTag1)
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
        foreach (GameObject obj in objectsWithTag2)
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
        foreach (GameObject obj in objectsWithTag3)
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
