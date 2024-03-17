

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool gameEnded = false;
    public Text oyunDurumText;
    public Button restart;
    public Button quit;
    void Update()
    {
        if (!gameEnded)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                remainingTime = 0;
                GameOver();
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {
        gameEnded = true;
        oyunDurumText.text = "Game Over"; 
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Debug.Log("Oyun Bitti");
        Time.timeScale = 0; 
    }
}