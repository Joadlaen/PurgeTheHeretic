using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectiveScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HomeSquad" || collision.gameObject.tag == "HomeTank")
        {

        }
    }
}
