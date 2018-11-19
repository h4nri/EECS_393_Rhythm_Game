using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTimingNote : MonoBehaviour {

	private GameObject link;
	private GameObject note;
	private GradeSprite gradeSprite;
	private ScoreManager scoreManager;
	private bool active; // Var to determine if a note is in a KeyboardTimingNote's collider
    public KeyCode key;

    private void Awake()
    {
		active = false;
	}

	private void Start()
    {
		link = null;
		note = null;
		gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
		scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
	}

	private void Update()
    {
		if (Input.GetKeyDown(key))
        {
			if (active)
            {
				if (link != null)
                {
					Destroy(link);
				}

				float distanceBetweenColliders = Mathf.Abs(GetComponent<CircleCollider2D>().transform.position.y - note.GetComponent<CircleCollider2D>().transform.position.y);
				scoreManager.AddScore(distanceBetweenColliders); // Amount of score added is based on distance between colliders of a KeyboardTimingNote and a note
				Destroy(note);
				active = false;
			} else // Hitting a key associated with a KeyboardTimingNote when it's not active counts as a miss
            {
				gradeSprite.SetSprite("Miss");
				scoreManager.EndStreak();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Note")
        {
			active = true;
			note = coll.gameObject;
			link = note.GetComponent<Note>().link;
		}
	}

	private void OnTriggerExit2D(Collider2D coll)
    {
		active = false;
	}
}
