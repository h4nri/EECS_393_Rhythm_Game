using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {

    //pause settings
    public static bool isPaused = false;

    public GameObject pauseMenu;
    

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
	}

    //in-game pause settings
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //audio settings 
    public void SetVolume (float volume)
    {
        float newVolume = AudioListener.volume;
        newVolume = volume;
        AudioListener.volume = newVolume;
    }

}
