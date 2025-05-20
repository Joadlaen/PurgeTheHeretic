using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObjectiveScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HomeTank" || other.tag == "HomeSquad" && 
            other.transform.position.x == this.transform.position.x && 
            other.transform.position.y == this.transform.position)
        {
            SceneManager.LoadScene("HomeWins");
        }


    }
}
