using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyObjectiveScript : MonoBehaviour
{
// before I simplified the win condition, this was intended to activate the win condition
// it didn't work as intended which is why the other win condition script exists.
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HomeTank" || other.tag == "HomeSquad" && 
            other.transform.position.x == this.transform.position.x && 
            other.transform.position.y == this.transform.position.y)
        {
            SceneManager.LoadScene("homeWins");
        }


    }
}
