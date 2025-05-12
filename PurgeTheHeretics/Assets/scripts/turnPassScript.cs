using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class turnPassScript : MonoBehaviour, IPointerDownHandler
{
    public main mainScript;
    public void OnPointerDown(PointerEventData eventData)
    {


        if (mainScript.Turn == "Home")
        {
            mainScript.Turn = "Enemy";
        }
        else if (mainScript.Turn == "Enemy")
        {
            mainScript.Turn = "Home";
        }
        Debug.Log(mainScript.gridTracker);
    }
}
