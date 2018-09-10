using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTimingNote : MonoBehaviour {

	GameObject link;
	GameObject note;
	GameObject scoreManager;
	GradeSprite gradeSprite;
	public KeyCode key;
	bool active = false;
	float distanceBetweenColliders;

	void Start () {
		scoreManager = GameObject.Find ("ScoreManager");
		gradeSprite = GameObject.Find ("Grade Image").GetComponent<GradeSprite> ();
	}

	void Update () {
		if (Input.GetKeyDown (key)) {
			if (active) {
				if (link != null) {
					Destroy (link);
				}

				distanceBetweenColliders = Mathf.Abs(GetComponent<CircleCollider2D> ().transform.position.y - note.GetComponent<CircleCollider2D> ().transform.position.y);
				print ("Distance between colliders: " + distanceBetweenColliders);
				scoreManager.GetComponent<ScoreManager> ().AddScore (distanceBetweenColliders);
				Destroy (note);
				active = false;
			} else {
				gradeSprite.SetSprite ("Miss");
				scoreManager.GetComponent<ScoreManager> ().EndStreak ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Note") {
			active = true;
			note = coll.gameObject;
			link = note.GetComponent<Note> ().link;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		active = false;
	}
}
