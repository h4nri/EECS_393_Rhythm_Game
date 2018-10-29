using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTimingNote : MonoBehaviour {

	GameObject link;
	GameObject note;
	ScoreManager scoreManager;
	Vector2 initialMousePos;
	bool active;
	bool trackingDirectionalNote;
	float distanceBetweenColliders;

	void Awake () {
		active = false;
		trackingDirectionalNote = false;
		distanceBetweenColliders = 0.0f;
	}

	void Start () {
		link = null;
		note = null;
		scoreManager = GameObject.Find ("Score Manager").GetComponent<ScoreManager> ();
		initialMousePos = new Vector2(0.0f, 0.0f);
	}

	void Update () {
		if (Input.GetMouseButtonUp(0) && trackingDirectionalNote) {
			//print ("Mouse Up Position: " + Input.mousePosition);
			Vector2 mouseDirection = new Vector2 (Input.mousePosition.x - initialMousePos.x, Input.mousePosition.y - initialMousePos.y);
			// print ("Modified Mouse Pos: " + modifiedMousePos);
			float angle = Vector2.SignedAngle (mouseDirection, Vector2.right);
			//print ("Angle: " + angle);

			if (angle <= -45.0f && angle >= -135.0f) {
				//print ("Direction: Up");
				if (note.GetComponent<Note> ().direction == "up") {
					ResolveHit ();
				}
			} else if (angle <= 135.0f && angle >= 45.0f) {
				//print ("Direction: Down");
				if (note.GetComponent<Note> ().direction == "Down") {
					ResolveHit ();
				}
			} else if (angle < -135.0f || angle > 135.0f) {
				//print ("Direction: Left");
				if (note.GetComponent<Note> ().direction == "Left") {
					ResolveHit ();
				}
			} else if (angle > -45.0f && angle < 45.0f) {
				//print ("Direction: Right");
				if (note.GetComponent<Note> ().direction == "Right") {
					ResolveHit ();
				}
			}
		}
	}

	void OnMouseDown() {
		//print ("Mouse Down Pos: " + Input.mousePosition);

		if (active) {
			if (note.GetComponent<Note> ().direction.Length == 0) {
				ResolveHit ();
			} else {
				trackingDirectionalNote = true;
				initialMousePos = Input.mousePosition;
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
		trackingDirectionalNote = false;
	}

	void ResolveHit () {
		if (link != null) {
			Destroy (link);
		}

		distanceBetweenColliders = Mathf.Abs (GetComponent<CircleCollider2D> ().transform.position.y - note.GetComponent<CircleCollider2D> ().transform.position.y);
		//print ("Distance between colliders: " + distanceBetweenColliders);
		scoreManager.AddScore (distanceBetweenColliders);
		Destroy (note);
		active = false;
	}
}
