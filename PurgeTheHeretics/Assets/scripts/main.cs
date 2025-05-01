using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject battleFieldSprite;
    public GameObject battleFieldCover;
    public GameObject homeSquadDeploy;
    public GameObject homeTankDeploy;
    public GameObject homeObjective;
    public GameObject EnemySquadDeploy;
    public GameObject EnemyTankDeploy;
    public GameObject enemyObjective;

    public int ROWS = 7;
    public int COLUMNS = 7;
    public float SPACING = 0.5f;
    public int enemyObjectPositionRow = 7;
    public int enemyObjectPositionCol = 7;
    public int homeObjectPositionRow = 0;
    public int homeObjectPositionCol = 0;
    public int homeSquadStrength = 6;
    public int centeringVariable = 0;

    // Start is called before the first frame update
    void Start()
    {
        GridGenerate();
    }

    // Update is called once per frame
    void Update()
    {

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

        Vector2 enemySquadPos = new Vector2(enemyObjectPositionCol * SPACING - (SPACING*2) - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable);
        Instantiate(EnemySquadDeploy, enemySquadPos, Quaternion.identity);

        Vector2 homeSquadPos = new Vector2(homeObjectPositionCol * SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable + SPACING);
        Instantiate(homeSquadDeploy, homeSquadPos, Quaternion.identity);

        Vector2 enemyTankPos = new Vector2(enemyObjectPositionCol * SPACING - SPACING - centeringVariable, enemyObjectPositionRow * SPACING - SPACING - centeringVariable - SPACING);
        Instantiate(EnemyTankDeploy, enemyTankPos, Quaternion.identity);

        Vector2 homeTankPos = new Vector2(homeObjectPositionCol * SPACING + SPACING - centeringVariable, homeObjectPositionRow * SPACING - centeringVariable);
        Instantiate(homeTankDeploy, homeTankPos, Quaternion.identity);
    }

}



