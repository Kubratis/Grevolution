using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butonlar : MonoBehaviour
{
    public coinText coinText;
   
    public void CikisButonu()
    {
        Application.Quit();

    }
    public void LevelBir()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadScene("LevelBir");
    }
   
    public void YenidenBasla()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Level›ki");
        coinText.ResetCoins();
    }
    public void BitisEkrani()
    {
        SceneManager.LoadScene("BitisEkrani");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level›ki");
    }
    public void RestartBir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelBir");
        coinText.ResetCoins();
    }
    public void PlayGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("LevelBir"); 
        coinText.ResetCoins();
    }

   
}
