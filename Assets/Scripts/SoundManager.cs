using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	AudioSource audioSource;
	AudioClip audioClip;
	float clipLength;

	void Start()
    {
		audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
		clipLength = audioClip.length;

		//print ("Clip Length: " + clipLength);
	}

	void Update()
    {
		// print ("Time: " + Time.timeSinceLevelLoad);

		if (Time.timeSinceLevelLoad - clipLength > 0.0f)
        {
			StartCoroutine("EndLevel");
		}
	}

	IEnumerator EndLevel()
    {
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Game Over");
	}
}
