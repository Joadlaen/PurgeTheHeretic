using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnDecider : MonoBehaviour
{
    //needed to specify system.random
    System.Random D6 = new System.Random();
    public int turnDecider;
    // Start is called before the first frame update
    public void TurnToDecide()
    {
        // random number generator operates as a coinflip. 50% of the time, home goes first, the rest is enemy.
        turnDecider = D6.Next(1,7);
        Debug.Log(turnDecider);
    }
}
