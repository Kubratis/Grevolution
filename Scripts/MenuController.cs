using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static bool gameIsPaused=false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject gamePlay;
    public GameObject panel;
    public Text volumeAmount;
    public Slider slider;

    private void Start()
    {
        LoadAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused )
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        
    }

    public void Resume()
    {
        Debug.Log("Resume() method called");
        pauseMenu.SetActive(false);
           panel.SetActive(false);
        Debug.Log("Panel active: " + panel.activeSelf);
        Time.timeScale = 1f;
           gameIsPaused = false;
    }
    public void Pause()
    {
        Debug.Log("Pause() method called");
        pauseMenu.SetActive(true);
        panel.SetActive(true);
        Debug.Log("Panel active: " + panel.activeSelf);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        gameIsPaused=true;
    }
    public void GamePlay()
    {
        pauseMenu.SetActive(false);
        gamePlay.SetActive(true);
        gameIsPaused = true;
    }
    public void YenidenBasla()
    {
        SceneManager.LoadScene(0);
    }
    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }
    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        volumeAmount.text=((int)(value *100)).ToString();
        SaveAudio();
    }
    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", AudioListener.volume);
    }
    void LoadAudio()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("audioVolume", 0f);
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
    }
}
