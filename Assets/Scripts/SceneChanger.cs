using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	public void ToLevelSelect() {
		SceneManager.LoadScene("Level Select");
	}

	public void ToSettings() {
		SceneManager.LoadScene("Settings");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void PlayTwinkleTwinkleLittleStar() {
		SceneManager.LoadScene("Twinkle Twinkle Little Star (Base)");
	}
}
