using System;
using UnityEngine;

public class MouseTimingNote : MonoBehaviour {

    private GameObject holdLine;
    private GameObject link;
	private GameObject note;
    private GradeSprite gradeSprite;
	private ScoreManager scoreManager;
	private Vector2 initialMousePos;
	private bool active; // Var to determine if a note is in a MouseTimingNote's collider
    private bool holding; // Var to determine if user is attempting to hit a hold note
    private bool trackingDirectionalNote; // Var to determine if current note is a directional note

    private void Awake ()
    {
		active = false;
        holding = false;
		trackingDirectionalNote = false;
	}

	private void Start ()
    {
        holdLine = null;
        link = null;
        note = null;
        gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
		initialMousePos = new Vector2(0.0f, 0.0f);
	}

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && trackingDirectionalNote)
        {
            Vector2 mouseDirection = new Vector2(Input.mousePosition.x - initialMousePos.x, Input.mousePosition.y - initialMousePos.y);
            float angle = Vector2.SignedAngle(mouseDirection, Vector2.right);

            // Hit directional notes if chosen direction (determined by value of angle) is correct
            string noteDirection = note.GetComponent<Note>().direction;

            if ((angle <= -45.0f && angle >= -135.0f && noteDirection.Equals("Up")) || (angle <= 135.0f && angle >= 45.0f && noteDirection.Equals("Down")) ||
                ((angle < -135.0f || angle > 135.0f) && noteDirection.Equals("Left")) || (angle > -45.0f && angle < 45.0f && noteDirection.Equals("Right")))
            {
                ResolveHit();
            }
            else
            {
                throw new Exception("Unexpected angle value.");
            }
        }
        else if (holdLine != null && holding)
        {
            // Var for how far a hold line is into a MouseTimingNote's collider 
            float inCollider = transform.position.y + GetComponent<CircleCollider2D>().radius - holdLine.GetComponent<HoldLine>().endpoint;

            if (inCollider >= 0)
            {
                holdLine.GetComponent<HoldLine>().length -= inCollider;

                if (holdLine.GetComponent<HoldLine>().length <= 0.0f)
                {
                    scoreManager.AddScore(0.0f);
                    Destroy(holdLine);
                    holding = false;
                }

                holdLine.transform.localScale = new Vector3(transform.localScale.x, holdLine.GetComponent<HoldLine>().length, transform.localScale.z);
                holdLine.transform.position = new Vector3(holdLine.transform.position.x, holdLine.transform.position.y + (inCollider / 2), holdLine.transform.position.z);
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

    private void OnMouseUp()
    {
        if (holdLine != null)
        {
            Destroy(holdLine);
            holding = false;
            gradeSprite.SetSprite("Miss");
            scoreManager.EndStreak();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.gameObject.tag.Equals("Note"))
        {
			active = true;
			note = coll.gameObject;
            holdLine = note.GetComponent<Note>().holdLine;
			link = note.GetComponent<Note>().link;
		}
	}

	private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Note"))
        {
            active = false;
            trackingDirectionalNote = false;
        }
	}

    // Resolve a note hit
	private void ResolveHit ()
    {
        if (holdLine != null)
        {
            holdLine.AddComponent<BoxCollider2D>().size = new Vector2(0.1f, 1.0f);
            holding = true;
        }

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
