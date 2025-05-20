using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeObjectiveScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        // same as enemy objective, it checks if the tags are looked out for as well as the position being the same
        if (other.tag == "EnTank" || other.tag == "EnSquad" &&
            other.transform.position.x == this.transform.position.x &&
            other.transform.position.y == this.transform.position.y)
        {
            SceneManager.LoadScene("HomeWins");
        }


    }
}
