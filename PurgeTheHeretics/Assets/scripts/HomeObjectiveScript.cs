using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeObjectiveScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemySquad" || collision.gameObject.tag == "EnemyTank")
        {

        }
    }
}
