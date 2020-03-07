using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text geoLocationText;

    public void UpdateCubeText(string cubeText) {
        geoLocationText.text = cubeText;
    }

}
