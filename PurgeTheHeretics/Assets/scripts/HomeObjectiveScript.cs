using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeObjectiveScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) < 0.1f)
        {
            Debug.Log(other.tag);
            if (other.tag == "EnTank" || other.tag == "EnSquad")
            {
                SceneManager.LoadScene("EnemyWins");
            }
        }
    }
}
