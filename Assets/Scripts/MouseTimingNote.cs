using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTimingNote : MonoBehaviour {

	private GameObject link;
	private GameObject note;
	private ScoreManager scoreManager;
	private Vector2 initialMousePos;
	private bool active; // Var to determine if a note is in a MouseTimingNote's collider
    private bool trackingDirectionalNote; // Var to determine if current note is a directional note

	private void Awake ()
    {
		active = false;
		trackingDirectionalNote = false;
	}

	private void Start ()
    {
		link = null;
		note = null;
		scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
		initialMousePos = new Vector2(0.0f, 0.0f);
	}

	private void Update ()
    {
		if (Input.GetMouseButtonUp(0) && trackingDirectionalNote)
        {
			Vector2 mouseDirection = new Vector2(Input.mousePosition.x - initialMousePos.x, Input.mousePosition.y - initialMousePos.y);
			float angle = Vector2.SignedAngle(mouseDirection, Vector2.right);

            // Determines the direction that a player slid their mouse based on angle, and
            // directional notes are hit if the chosen direction was correct
			if (angle <= -45.0f && angle >= -135.0f)
            {
				//print("Direction: Up");
				if (note.GetComponent<Note>().direction == "Up")
                {
					ResolveHit();
				}
			} else if (angle <= 135.0f && angle >= 45.0f)
            {
				//print("Direction: Down");
				if (note.GetComponent<Note>().direction == "Down")
                {
					ResolveHit();
				}
			} else if (angle < -135.0f || angle > 135.0f)
            {
				//print("Direction: Left");
				if (note.GetComponent<Note>().direction == "Left")
                {
					ResolveHit();
				}
			} else if (angle > -45.0f && angle < 45.0f)
            {
				//print("Direction: Right");
				if (note.GetComponent<Note>().direction == "Right")
                {
					ResolveHit();
				}
			}
		}
	}

	private void OnMouseDown()
    {
		if (active)
        {
            // Checks whether or not the note in a MouseTimingNote's collider is a directional note
            if (note.GetComponent<Note>().direction.Length == 0)
            {
				ResolveHit();
			} else {
				trackingDirectionalNote = true;
				initialMousePos = Input.mousePosition;
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
		trackingDirectionalNote = false;
	}

	private void ResolveHit ()
    {
		if (link != null)
        {
			Destroy(link);
		}

		float distanceBetweenColliders = Mathf.Abs(GetComponent<CircleCollider2D>().transform.position.y - note.GetComponent<CircleCollider2D>().transform.position.y);
		scoreManager.AddScore(distanceBetweenColliders); // Amount of score added is based on distance between colliders of a KeyboardTimingNote and a note
        Destroy(note);
		active = false;
	}
}
