using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script should be added as a component to all buttons' texts in the Leaderboards scene 
public class Leaderboards : MonoBehaviour {
    string level;
    string highscores;

	private void Start()
    {
        level = GetComponent<Text>().text;
        print(level);
        highscores = level + ("\n\nHigh Scores: ") + PlayerPrefs.GetInt(level + "1") + ", " + PlayerPrefs.GetInt(level + "2") + ", " + PlayerPrefs.GetInt(level + "3");
        GetComponent<Text>().text = highscores;
    }
}
