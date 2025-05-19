using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class volumeScript : MonoBehaviour
{
    public int volume;
    public TextMeshProUGUI volumeIndicate;

    // Update is called once per frame
    void Update()
    {
        volumeIndicate.text = volume.ToString();
    }
}
