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

    // declare as vector3 to preserve rendering. the onjectives and pieces would spawn under the battlefield tiles if not leaving a white square.
    public Vector3 enemySquadPos;
    public Vector3 enemyTankPos;
    public Vector3 homeSquadPos;
    public Vector3 homeTankPos;

    //declare all objects that need to be instantiated or teleported 
    public GameObject battleFieldSprite;
    public GameObject battleFieldCover;
    public GameObject homeSquadDeploy;
    public GameObject homeTankDeploy;
    public GameObject homeObjective;
    public GameObject EnemySquadDeploy;
    public GameObject EnemyTankDeploy;
    public GameObject enemyObjective;

    // declare scripts that contain variables tha are in use by this script
    public EnemyTankScript enemyTankScript;
    public EnemySquadScript enemySquadScript;
    public HomeTankScript homeTankScript;
    public HomeSquadScript homeSquadScript;
    public TurnDecider turnToPlay;

    // declare constants and variables for producing the grid
    public int ROWS = 5;
    public int COLUMNS = 5;
    public float SPACING = 0.5f;
    public int enemyObjectPositionRow = 5;
    public int enemyObjectPositionCol = 5;
    public int homeObjectPositionRow = 0;
    public int homeObjectPositionCol = 0;
    public int centeringVariable = 2;
    public string CurrentPhase = "Movement";
    public string Turn = "";



    // Start is called before the first frame update
    void Start()
    {
        // initialse the array as a mirror for the grid
        gridTracker = new string[ROWS, COLUMNS];
        GridGenerate();
        // call function in another script
        turnToPlay.TurnToDecide();
        Debug.Log(turnToPlay.turnDecider);
        // dictate who goes first using turn decider script
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
        // array keeps track of the locations of each piece on the battlefield while they are still there. this mostly pertains to the shooting script
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
        // nested for loop generates the rectangular shape, can be square in some cases
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLUMNS; j++)
            {
                Vector3 position = new Vector3(j * SPACING - centeringVariable, i * SPACING - centeringVariable, 2f);
                Instantiate(battleFieldSprite, position, Quaternion.identity);
            }
        }
        // set up objctive markers and player deployment pieces for each player by calling the custom finction Teleport
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
    // teleport function moves the object to the required space
    private void Teleport(GameObject ObjectToMove, Vector2 targetPosition, Quaternion rotation)
    {
        Debug.Log(ObjectToMove.name + targetPosition.ToString() + rotation.ToString());
        ObjectToMove.transform.position = targetPosition;
        ObjectToMove.transform.rotation = rotation;
    }
}
//declare a new class to be inherited
public class Stats: MonoBehaviour
{
    // most objects within were made for the shooting script but some constants used in other scripts could easily be objects from an inherited subclass
    public string pieceName = "";
    public int attacks = 0;
    public int accuracy = 0;
    public int wounding = 0;
    public int damage= 0;
    public int wounds = 0;
    public bool dead = false;
}



