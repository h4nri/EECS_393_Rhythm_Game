using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{

	public void ToLevelSelect()
    {
		SceneManager.LoadScene("Level Select");
	}

    public void SaveScene()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
    }

    //Return to the last saved scene
    public void BackToLast()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");

        SceneManager.LoadScene(sceneName);

        //TODO: Fix bug that makes it so that when returning from settings or instructions the pause menu is not active.
        //Check if game is paused to set the correct active panel (pause menu)
        //if (SettingsManager.isPaused) 
        //{
         //   GameObject pauseMenu;
        //    pauseMenu.SetActive(true);
       // }
 
    }
	public void ToSettings()
    {
		SceneManager.LoadScene("Settings");
	}

    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToLeaderBoards()
    {
        SceneManager.LoadScene("LeaderBoards");
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
		Application.Quit();
	}

	public void PlayTwinkleTwinkleLittleStar()
    {
		SceneManager.LoadScene("Twinkle Twinkle Little Star");
	}
}
