using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class main : MonoBehaviour
{
    public string[,] gridTracker;

    public Vector3 enemySquadPos;
    public Vector3 enemyTankPos;
    public Vector3 homeSquadPos;
    public Vector3 homeTankPos;

    public GameObject battleFieldSprite;
    public GameObject battleFieldCover;
    public GameObject homeSquadDeploy;
    public GameObject homeTankDeploy;
    public GameObject homeObjective;
    public GameObject EnemySquadDeploy;
    public GameObject EnemyTankDeploy;
    public GameObject enemyObjective;


    public EnemyTankScript enemyTankScript;
    public EnemySquadScript enemySquadScript;
    public HomeTankScript homeTankScript;
    public HomeSquadScript homeSquadScript;
    public TurnDecider turnToPlay;

    public int ROWS = 7;
    public int COLUMNS = 7;
    public float SPACING = 0.5f;
    public int enemyObjectPositionRow = 7;
    public int enemyObjectPositionCol = 7;
    public int homeObjectPositionRow = 0;
    public int homeObjectPositionCol = 0;
    public int centeringVariable = 3;
    public string CurrentPhase = "Movement";
    public string Turn = "";



    // Start is called before the first frame update
    void Start()
    {
        gridTracker = new string[ROWS, COLUMNS];
        GridGenerate();
        turnToPlay.TurnToDecide();
        Debug.Log(turnToPlay.turnDecider);
        if (turnToPlay.turnDecider <= 3)
        {
            Turn = "Enemy";
        }
        else if (turnToPlay.turnDecider >=4)
        {
            Turn = "Home";
        }
        Debug.Log(Turn);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySquadScript.enabled != null) 
        {
            gridTracker[(int)enemySquadScript.enemySquadMovement.x + centeringVariable, (int)enemySquadScript.enemySquadMovement.y + centeringVariable] = "EnSquad";
        }
        if (homeSquadScript.enabled != null)
        {
            gridTracker[(int)homeSquadScript.homeSquadMovement.x + centeringVariable, (int)homeSquadScript.homeSquadMovement.y + centeringVariable] = "HomeSquad";
        }
        if (homeTankScript.enabled != null)
        {
            gridTracker[(int)homeTankScript.homeTankMovement.x + centeringVariable, (int)homeTankScript.homeTankMovement.y + centeringVariable] = "HomeTank";
        }
        if (enemyTankScript.enabled != null)
        { 
            gridTracker[(int)enemyTankScript.enemyTankMovement.x + centeringVariable, (int)enemyTankScript.enemyTankMovement.y + centeringVariable] = "EnTank";
        }
    }

    public void GridGenerate()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                Vector3 position = new Vector3(j * SPACING - centeringVariable, i * SPACING - centeringVariable, 2f);
                Instantiate(battleFieldSprite, position, Quaternion.identity);
            }
        }
        Vector3 enemyObjectivePos = new Vector3(enemyObjectPositionCol * SPACING - SPACING - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable, 1f);
        Teleport(enemyObjective, enemyObjectivePos, Quaternion.identity);

        Vector3 homeObjectivePos = new Vector3(homeObjectPositionCol * SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable, 1f);
        Teleport(homeObjective, homeObjectivePos, Quaternion.identity);

        enemySquadPos = new Vector3(enemyObjectPositionCol * SPACING - (SPACING*2) - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable, 1f);
        Teleport(EnemySquadDeploy, enemySquadPos, Quaternion.identity);

        homeSquadPos = new Vector3(homeObjectPositionCol * SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable + SPACING, 1f);
        Teleport(homeSquadDeploy, homeSquadPos, Quaternion.identity);

        enemyTankPos = new Vector3(enemyObjectPositionCol * SPACING - SPACING - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable - SPACING, 1f);
        Teleport(EnemyTankDeploy, enemyTankPos, Quaternion.identity);

        homeTankPos = new Vector3(homeObjectPositionCol * SPACING + SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable, 1f);
        Teleport(homeTankDeploy, homeTankPos, Quaternion.identity);
    }
    private void Teleport(GameObject ObjectToMove, Vector2 targetPosition, Quaternion rotation)
    {
        Debug.Log(ObjectToMove.name + targetPosition.ToString() + rotation.ToString());
        ObjectToMove.transform.position = targetPosition;
        ObjectToMove.transform.rotation = rotation;
    }
}

public class Stats: MonoBehaviour
{
    public string pieceName = "";
    public int attacks = 0;
    public int accuracy = 0;
    public int wounding = 0;
    public int damage= 0;
    public int wounds = 0;
}



