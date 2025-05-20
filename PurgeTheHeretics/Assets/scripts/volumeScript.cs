using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class volumeScript : MonoBehaviour
{
    // intended to work with an mp player in the game scene to play music at a given volume, i was not able to implement theis
    public int volume;
    // it would display the volume in the main menu scene on a text mesh pro
    public TextMeshProUGUI volumeIndicate;

    // Update is called once per frame
    void Update()
    {
        volumeIndicate.text = volume.ToString();
        // this function kept track of the current value
    }
    // a pointer event would be used which would take the tag of the button and increase or decrease the variable that controled the volume
}
