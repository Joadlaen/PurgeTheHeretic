using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class main : MonoBehaviour
{
    public string[,] gridTracker;

    public Vector2 enemySquadPos;
    public Vector2 enemyTankPos;
    public Vector2 homeSquadPos;
    public Vector2 homeTankPos;

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
    public int homeSquadStrength = 6;
    public int centeringVariable = 3;
    public string CurrentPhase = "Movement";
    public string Turn = "";

    //        bool[,] blockedSquares = new bool[GRID_SIZE, GRID_SIZE];



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
        if (enemySquadScript.enabled == true) 
        {
            gridTracker[(int)enemySquadScript.enemySquadMovement.x, (int)enemySquadScript.enemySquadMovement.y] = "EnSquad";
        }
        if (homeSquadScript.enabled == true)
        {
            gridTracker[(int)homeSquadScript.homeSquadMovement.x, (int)homeSquadScript.homeSquadMovement.y] = "HomeSquad";
        }
        if (homeTankScript.enabled == true)
        {
            gridTracker[(int)homeTankScript.homeTankMovement.x, (int)homeTankScript.homeTankMovement.y] = "HomeTank";
        }
        if (enemyTankScript.enabled == true)
        { 
            gridTracker[(int)enemyTankScript.enemyTankMovement.x, (int)enemyTankScript.enemyTankMovement.y] = "EnTank";
        }
    }

    public void GridGenerate()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                Vector2 position = new Vector2(j * SPACING - centeringVariable, i * SPACING - centeringVariable);
                Instantiate(battleFieldSprite, position, Quaternion.identity);
            }
        }
        Vector2 enemyObjectivePos = new Vector2(enemyObjectPositionCol * SPACING - SPACING - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable);
        Instantiate(enemyObjective, enemyObjectivePos, Quaternion.identity);

        Vector2 homeObjectivePos = new Vector2(homeObjectPositionCol * SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable);
        Instantiate(homeObjective, homeObjectivePos, Quaternion.identity);

        enemySquadPos = new Vector2(enemyObjectPositionCol * SPACING - (SPACING*2) - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable);
        Instantiate(EnemySquadDeploy, enemySquadPos, Quaternion.identity);

        homeSquadPos = new Vector2(homeObjectPositionCol * SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable + SPACING);
        Instantiate(homeSquadDeploy, homeSquadPos, Quaternion.identity);

        enemyTankPos = new Vector2(enemyObjectPositionCol * SPACING - SPACING - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable - SPACING);
        Instantiate(EnemyTankDeploy, enemyTankPos, Quaternion.identity);

        homeTankPos = new Vector2(homeObjectPositionCol * SPACING + SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable);
        Instantiate(homeTankDeploy, homeTankPos, Quaternion.identity);
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



