using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	private AudioSource audioSource;
	private AudioClip audioClip;
	private float clipLength;

	private void Start()
    {
        audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
		clipLength = audioClip.length;
        //adding dont destroy for testing
        //DontDestroyOnLoad(transform.gameObject);

        //print("Clip Length: " + clipLength);
    }

	private void Update()
    {
		// print("Time: " + Time.timeSinceLevelLoad);

		if (Time.timeSinceLevelLoad - clipLength > 0.0f)
        {
			StartCoroutine("EndLevel");
		}

        //Check if the game is paused. If so, pause audio 
        if (SettingsManager.isPaused)
        {
            audioSource.Pause();
        }

        //Check if the game is unpaused. If so, unpause audio 
        else if (!(SettingsManager.isPaused))
        {
            audioSource.UnPause();
        }
    }

	IEnumerator EndLevel()
    {
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Game Over");
	}
}
