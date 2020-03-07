using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text geoLocationText;

    // Start is called before the first frame update
    void Start()
    {
        geoLocationText.text = "I have changed the text!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
