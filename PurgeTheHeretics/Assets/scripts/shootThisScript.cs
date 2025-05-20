using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootThisScript : MonoBehaviour, IPointerDownHandler
{
    System.Random D6 = new System.Random();
    public GameObject homeTank;
    public HomeTankScript homeTankscript;
    public GameObject enemyTank;
    public EnemyTankScript enemyTankScript;
    public GameObject homeSquad;
    public HomeSquadScript homeSquadScript;
    public GameObject enemySquad;
    public EnemySquadScript enemySquadScript;
    public GameObject shootPos;
    private GameObject shootTarget;
    public main mainScript;

    public string nameShooting = "";
    public int hits = 0;
    public int rollHits = 0;
    public int wounds = 0;
    public int rollWounds = 0;
    public Camera mainCamera;



    public void UpdateNameShooting(string name)
    {
        nameShooting = name;
    }
    //shows where the guns should be firing at
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 worldPos = transform.position;
        int x = Mathf.RoundToInt(worldPos.x);
        int y = Mathf.RoundToInt(worldPos.y);
        if (mainScript.gridTracker[x, y] != null)
        {
            if (mainScript.gridTracker[x, y] == "HomeSquad")
            {
                shootTarget = homeSquad;

                if (nameShooting == "EnTank")
                {
                    ShootAtThings(enemyTank, shootTarget);
                }
                if (nameShooting == "EnSquad")
                {
                    ShootAtThings(enemySquad, shootTarget);
                }
            }
            if (mainScript.gridTracker[x, y] == "HomeTank")
            {
                shootTarget = homeTank;

                if (nameShooting == "EnTank")
                {
                    ShootAtThings(enemyTank, shootTarget);
                }
                if (nameShooting == "EnSquad")
                {
                    ShootAtThings(enemySquad, shootTarget);
                }
            }
            if (mainScript.gridTracker[x, y] == "EnTank")
            {
                shootTarget = enemyTank;
                if (nameShooting == "HomeTank")
                {
                    ShootAtThings(homeTank, shootTarget);
                }
                if (nameShooting == "HomeSquad")
                {
                    ShootAtThings(homeSquad, shootTarget);
                }
            }
            if (mainScript.gridTracker[x, y] == "EnTank")
            {
                shootTarget = enemyTank;
                if (nameShooting == "HomeTank")
                {
                    ShootAtThings(homeTank, shootTarget);
                }
                if (nameShooting == "HomeSquad")
                {
                    ShootAtThings(homeSquad, shootTarget);
                }
            }
        }
    }
    





    public void ShootAtThings(GameObject objectFiring, GameObject objectTarget)
    {
        Stats attackerStats = objectFiring.GetComponent<Stats>();
        Stats targetStats = objectTarget.GetComponent<Stats>();

        rollHits = 0;
        rollWounds = 0;

        for (int i = 0; i < attackerStats.attacks; i++)
        {
            hits = D6.Next(1, 7);
            if (hits >= attackerStats.accuracy)
            {
                rollHits++;
            }
        }

        for (int i = 0; i < rollHits; i++)
        {
            wounds = D6.Next(1, 7);
            if (wounds >= attackerStats.wounding)
            {
                rollWounds++;
            }
        }

        if (rollWounds > 0)
        {
            targetStats.wounds -= rollWounds * attackerStats.damage;
            Debug.Log($"{nameShooting} did {rollWounds * attackerStats.damage} damage to {objectTarget.name}");
        }
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
