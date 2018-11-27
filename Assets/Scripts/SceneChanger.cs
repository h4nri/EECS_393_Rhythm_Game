using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{

	public void ToLevelSelect()
    {
		SceneManager.LoadScene("Level Select");
        //Time.timeScale = 0;
    }

    public void SaveScene()
    {

        //case in which the game is paused
        if (SettingsManager.isPaused)
        {
            //GameObject pauseMenu = GameObject.Find("PauseMenu");
            //GameObject.Find("PauseMenu").SetActive(false);
            //Time.timeScale = 0f;
            // SettingsManager.isPaused = true;
        }

        //adding dont destroy for testing
        //DontDestroyOnLoad(transform.gameObject);

        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
    }

    //Return to the last saved scene
    public void BackToLast()
    {
        //adding dont destroy for testing
        //DontDestroyOnLoad(transform.gameObject);
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");

        SceneManager.LoadScene(sceneName);

        //case in which the game is paused
        if (SettingsManager.isPaused)
        {
           // GameObject pauseMenu = GameObject.Find("PauseMenu");
          //  pauseMenu.SetActive(true);
            //Time.timeScale = 0f;
           // SettingsManager.isPaused = true;
        }
 
    }



    //Instructions scene does not need to save its state, so it can just be addtive
    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Additive);
    }

    public void UnloadInstructions()
    {
        SceneManager.UnloadScene("Instructions");
    }

    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Settings"));
    }

    public void UnloadSettings()
    {
        SceneManager.UnloadScene("Settings");
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
        //DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("Twinkle Twinkle Little Star");
	}
}
