using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	GradeSprite gradeSprite;
	ScoreManager scoreManager;

	void Start()
    {
		gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
		scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
	}

	void Update()
    {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
		Destroy(coll.gameObject);
		gradeSprite.SetSprite("Miss");
		scoreManager.EndStreak();
	}
}
