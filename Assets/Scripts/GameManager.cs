using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	GameObject scoreManager;
	GradeSprite gradeSprite;

	void Start () {
		scoreManager = GameObject.Find ("ScoreManager");
		gradeSprite = GameObject.Find ("Grade Image").GetComponent<GradeSprite> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Destroy (coll.gameObject);
		gradeSprite.SetSprite ("Miss");
		scoreManager.GetComponent<ScoreManager> ().EndStreak ();
	}
}
