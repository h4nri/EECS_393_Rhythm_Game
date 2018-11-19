using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour{

	public void ToLevelSelect()
    {
		SceneManager.LoadScene("Level Select");
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
