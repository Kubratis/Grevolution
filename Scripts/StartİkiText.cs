using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartİkiText : MonoBehaviour
{
    public TextMeshProUGUI startikiText;

    public float displayTime = 4f; 
    void Start()
    {
        
        startikiText.SetText("Year 2024 Game Started");
        startikiText.gameObject.SetActive(true);
        Invoke("HideText", displayTime);
    }

    void HideText()
    {
        startikiText.SetText("");
        startikiText.gameObject.SetActive(false);
    }
}
