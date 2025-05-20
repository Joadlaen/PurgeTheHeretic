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
        // checks the position of the object that is clicked.
        Vector2 worldPos = transform.position;
        int x = Mathf.RoundToInt(worldPos.x);
        int y = Mathf.RoundToInt(worldPos.y);
        // checks if anything is even there
        if (mainScript.gridTracker[x + mainScript.centeringVariable, y + mainScript.centeringVariable] != null)
        {
            // checks the tag of the target used in the gridtracker array and sets the target to the corresponding object. it sets the attacker to the corresponding object by checking the value in nameShooting
            if (mainScript.gridTracker[x + mainScript.centeringVariable, y + mainScript.centeringVariable] == "HomeSquad")
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
            if (mainScript.gridTracker[x + mainScript.centeringVariable, y + mainScript.centeringVariable] == "HomeTank")
            {
                shootTarget = homeTank;

                if (nameShooting == "EnTank")
                {
                    ShootAtThings(enemyTank, shootTarget);
                }
                if (nameShooting == "EnSquad")
                {
                    enemySquadScript.shotPiece = true;
                    ShootAtThings(enemySquad, shootTarget);
                }
            }
            if (mainScript.gridTracker[x + mainScript.centeringVariable, y + mainScript.centeringVariable] == "EnTank")
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
            if (mainScript.gridTracker[x + mainScript.centeringVariable, y + mainScript.centeringVariable] == "EnTank")
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
        else;
        {
            Debug.Log("nothing there");
        }
    }
    





    public void ShootAtThings(GameObject objectFiring, GameObject objectTarget)
    {
        // obtains the stat blocks from each object
            Stats attackerStats = objectFiring.GetComponent<Stats>();
        Stats targetStats = objectTarget.GetComponent<Stats>();

        //resets the variables 
        rollHits = 0;
        rollWounds = 0;
        // rolls hits for each available attack
        for (int i = 0; i < attackerStats.attacks; i++)
        {
            hits = D6.Next(1, 7);
            if (hits >= attackerStats.accuracy)
            {
                rollHits++;
            }
        }
        // rolls wounds for each available hit
        for (int i = 0; i < rollHits; i++)
        {
            wounds = D6.Next(1, 7);
            if (wounds >= attackerStats.wounding)
            {
                rollWounds++;
            }
        }
        // calculates the damage based on the success rate of the hits and wounds, a third armour save step could have been added which would do the same with some extra external features.
        if (rollWounds > 0)
        {
            targetStats.wounds -= rollWounds * attackerStats.damage;
            Debug.Log($"{nameShooting} did {rollWounds * attackerStats.damage} damage to {objectTarget.name}");
        }

    }

}
