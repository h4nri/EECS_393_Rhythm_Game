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

    public void CreateNewLevel()
    {
        SceneManager.LoadScene("Level Base");
    }

    public void ToCustomLevelSelect()
    {
        CustomLevelData.LevelData.Load();
        SceneManager.LoadScene("Custom Level Select");
    }

    public void ToLevelEditor()
    {
        SceneManager.LoadScene("Level Editor");
    }

    public void ToPlayCustomLevel()
    {
        SceneManager.LoadScene("Custom Level Play");
    }

    public void ToEditCustomLevel() 
    {
        // TODO change this to actually load the current level. 
        SceneManager.LoadScene("Level Editor");
    }
}
