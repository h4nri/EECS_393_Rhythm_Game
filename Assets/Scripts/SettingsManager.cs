using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {

    //pause settings
    public static bool isPaused = false;
    public static bool settingsOpen = false;
    public static bool instructionsOpen = false;

    //pause menu and game objects
    public GameObject gameCanvas;
    public GameObject settingsCanvas;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject instructionsMenu;
    

    private void Start()
    {
        //at the start only the game should be active
        gameCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        instructionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameCanvas.activeInHierarchy)
            {
                if (isPaused)
                {
                    ResumeGame();
                }

                else
                {
                    PauseGame();
                }
            }
        }
	}

    //in-game pause settings
    public void ResumeGame()
    {
        if (!settingsOpen & !instructionsOpen)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        else;
    }
    
    //Pause Menu and Settings functions
    public void ToSettingsCanvas()
    {
        gameCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        Debug.Log("ToSettingsCanvas");
    }

    public void QuitSettingsCanvas()
    {
        gameCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ToSettings()
    {
        pauseMenu.SetActive(false);
        ToSettingsCanvas();
        settingsMenu.gameObject.SetActive(true);
        settingsOpen = true;
    }

    public void QuitSettings()
    {
        settingsMenu.gameObject.SetActive(false);
        QuitSettingsCanvas();
        pauseMenu.SetActive(true);
        settingsOpen = false;
    }

    public void ToInstructions()
    {
        pauseMenu.SetActive(false);
        Debug.Log("ToInstructions");
        ToSettingsCanvas();
        instructionsMenu.SetActive(true);
        instructionsOpen = true;
    }

    public void QuitInstructions()
    {
        instructionsMenu.gameObject.SetActive(false);
        QuitSettingsCanvas();
        pauseMenu.SetActive(true);
        instructionsOpen = false;
    }

    //audio settings 
    public void SetVolume (float volume)
    {
        float newVolume = AudioListener.volume;
        newVolume = volume;
        AudioListener.volume = newVolume;
    }

    //mouse sensitivity settings
    public void SetMouseSensitivity(float sensitivity)
    {
        Vector2 mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X") * sensitivity, Input.GetAxisRaw("Mouse Y") * sensitivity);
    }
}
