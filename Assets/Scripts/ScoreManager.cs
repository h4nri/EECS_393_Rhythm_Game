using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	GradeSprite gradeSprite;
	int multiplier;
	int score;
	int streak;
	float areaOfOverlap;
	float overlapPercentage;

	void Start () {
		gradeSprite = GameObject.Find ("Grade Image").GetComponent<GradeSprite> ();
		multiplier = 1;
		score = 0;
		streak = 0;
	}

	void Update () {
		GetComponent<Text> ().text = score + "\n" + streak + "\n" + multiplier + "x";
	}

	public void AddScore(float distance) {
		areaOfOverlap = (2 * Mathf.Pow(0.5f, 2.0f) * Mathf.Acos (distance / (2 * 0.5f))) - ((distance / 2) * (Mathf.Sqrt (4 * Mathf.Pow(0.5f, 2.0f)) - Mathf.Pow(distance, 2.0f)));
		overlapPercentage = areaOfOverlap / (Mathf.PI * Mathf.Pow(0.5f, 2.0f));

		print ("Overlap percentage: " + overlapPercentage);

		if ((overlapPercentage <= 1.0f) && (overlapPercentage > 0.8f)) {
			gradeSprite.SetSprite ("Perfect");
			score = score + (1000 * multiplier);
			streak++;
		} else if ((overlapPercentage <= 0.8f) && (overlapPercentage > 0.6f)) {
			gradeSprite.SetSprite ("Great");
			score = score + (850 * multiplier);
			streak++;
		} else if ((overlapPercentage <= 0.6f) && (overlapPercentage > 0.4f)) {
			gradeSprite.SetSprite ("Good");
			score = score + (500 * multiplier);
			EndStreak ();
		} else if ((overlapPercentage <= 0.4f) && (overlapPercentage > 0.0f)) {
			gradeSprite.SetSprite ("Bad");
			score = score + (100 * multiplier);
			EndStreak ();
		}
			
		if ((streak >= 10) && (streak < 20)) {
			multiplier = 2;
		} else if (streak >= 20) {
			multiplier = 3;
		}
	}

	public void EndStreak() {
		streak = 0;
		multiplier = 1;
	}
}
