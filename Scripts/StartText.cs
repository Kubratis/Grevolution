using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI startText;
    
    public float displayTime = 4f; 

    void Start()
    {
       
        startText.SetText("Year 2010 Game Started");
        startText.gameObject.SetActive(true);
        Invoke("HideText", displayTime);
    }

    void HideText()
    {
        startText.SetText("");
        startText.gameObject.SetActive(false);
    }
}
