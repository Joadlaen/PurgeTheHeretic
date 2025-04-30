using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject battleFieldSprite;
    public GameObject battleFieldCover;
    public GameObject battleFieldDeploy;
    public GameObject homeObjective;
    public GameObject enemyObjective;

    public int ROWS = 7;
    public int COLUMNS = 7;
    public float SPACING = 0.5f;
    public int enemyObjectPositionRow = 7;
    public int enemyObjectPositionCol = 7;
    public int homeObjectPositionRow = 0;
    public int homeObjectPositionCol = 0;

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
                Vector2 position = new Vector2(j * SPACING, i * SPACING);
                Instantiate(battleFieldSprite, position, Quaternion.identity);
            }
        }
        Vector2 enemyObjectivePos = new Vector2(enemyObjectPositionCol * SPACING, enemyObjectPositionRow * SPACING);
        Instantiate(enemyObjective, enemyObjectivePos, Quaternion.identity);

        Vector2 homeObjectivePos = new Vector2(homeObjectPositionCol * SPACING, homeObjectPositionRow * SPACING);
        Instantiate(homeObjective, homeObjectivePos, Quaternion.identity);
    }

}



