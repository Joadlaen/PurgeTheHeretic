using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObjectiveScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (Vector3.Distance(transform.position, other.transform.position) < 0.1f)
        {
            Debug.Log("winner is " + other.tag);
            if (other.tag == "HomeTank" || other.tag == "HomeSquad")
            {
                SceneManager.LoadScene("HomeWins");
            }
        }
    }
}
