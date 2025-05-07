using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class HomeTankScript : MonoBehaviour, IPointerDownHandler
{
    System.Random D6 = new System.Random();
    public GameObject moveTint;
    public GameObject shootTint;
    public GameObject enemySquad;

    public main mainScript;

    const int RANGE = 6;
    const int MOVEMENT = 2;
    const int SPACING = 1;
    const int centeringVariable = 0;




    public void OnPointerDown(PointerEventData eventData)
    {
        if (mainScript != null && mainScript.Turn == "Home")
        {
            int Advancer = D6.Next(1, 7);
            Debug.Log("EnemySquad");
            if (mainScript.CurrentPhase == "Movement")
            {
                moveDirectionGenerate();
            }
            if (mainScript.CurrentPhase == "Shooting")
            {
                shootDirectionGenerate();
            }
        }
    }

    public void moveDirectionGenerate()
    {
        for (int i = 0; i < MOVEMENT; i++)
        {
            for (int j = 0; j < MOVEMENT; j++)
            {
                Vector2 position = new Vector2(j * SPACING - centeringVariable, i * SPACING - centeringVariable);
                Instantiate(moveTint, position, Quaternion.identity);
            }
        }
    }
    public void shootDirectionGenerate()
    {

    }
}
