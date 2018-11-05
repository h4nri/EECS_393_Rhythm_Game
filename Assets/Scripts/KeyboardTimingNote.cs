using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTimingNote : MonoBehaviour {

	GameObject link;
	GameObject note;
	GradeSprite gradeSprite;
	public KeyCode key;
	ScoreManager scoreManager;
	bool active;
	float distanceBetweenColliders;

	void Awake()
    {
		active = false;
		distanceBetweenColliders = 0.0f;
	}

	void Start()
    {
		link = null;
		note = null;
		gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
		scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
	}

	void Update()
    {
		if (Input.GetKeyDown(key))
        {
			if (active)
            {
				if (link != null)
                {
					Destroy(link);
				}

				distanceBetweenColliders = Mathf.Abs(GetComponent<CircleCollider2D>().transform.position.y - note.GetComponent<CircleCollider2D>().transform.position.y);
				//print ("Distance between colliders: " + distanceBetweenColliders);
				scoreManager.AddScore(distanceBetweenColliders);
				Destroy(note);
				active = false;
			} else
            {
				gradeSprite.SetSprite("Miss");
				scoreManager.EndStreak();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Note")
        {
			active = true;
			note = coll.gameObject;
			link = note.GetComponent<Note>().link;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
    {
		active = false;
	}
}
