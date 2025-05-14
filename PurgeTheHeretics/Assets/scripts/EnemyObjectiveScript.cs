using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectiveScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //if (collision.gameObject.tag == "HomeSquad" || collision.gameObject.tag == "HomeTank")
        //{

        //}
        if (Vector3.Distance(transform.position, other.transform.position) < 0.1f)
        {
            Debug.Log("Object with tag " + other.tag + " is in the same position!");
            // Your logic here
        }
    }
}
