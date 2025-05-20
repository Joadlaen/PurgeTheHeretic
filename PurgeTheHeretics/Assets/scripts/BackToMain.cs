using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        //the button on both ending screens loads the main menu where i intend to add volume and quit options if given more time
        SceneManager.LoadScene("mainMenu");
    }
}
