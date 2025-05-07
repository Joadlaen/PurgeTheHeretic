using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootThisScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject homeTank;
    public GameObject enemyTank;
    public GameObject homeSquad;
    public GameObject enemySquad;
    public GameObject shootPos;

    //shows where the guns should be firing at
    public void OnPointerDown(PointerEventData eventData)
    {

    }

}
