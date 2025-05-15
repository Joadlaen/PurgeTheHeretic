using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnDecider : MonoBehaviour
{
    System.Random D6 = new System.Random();
    public int turnDecider;
    // Start is called before the first frame update
    public void TurnToDecide()
    {
        turnDecider = D6.Next(1,7);
        Debug.Log(turnDecider);
    }
}
