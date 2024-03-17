using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Camera mapCamera;
    public GameObject player;
    public GameObject canvas;

    void Start()
    {
        mapCamera.gameObject.SetActive(false); 
        player.GetComponent<PlayerController>().enabled = true; 
        canvas.SetActive(true); 
        mapCamera.fieldOfView = 90f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap(); 
        }
    }

    void ToggleMap()
    {
        bool mapActive = !mapCamera.gameObject.activeSelf; 
        mapCamera.gameObject.SetActive(mapActive); 
        player.GetComponent<PlayerController>().enabled = !mapActive; 
        canvas.SetActive(!mapActive); 
    }
}