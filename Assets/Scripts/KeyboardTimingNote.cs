using UnityEngine;

public class KeyboardTimingNote : MonoBehaviour {

    private GameObject holdLine;
    private GameObject link;
	private GameObject note;
	private GradeSprite gradeSprite;
	private ScoreManager scoreManager;
	private bool active; // Var to determine if a note is in a KeyboardTimingNote's collider
    private bool holding; // Var to determine if user is attempting to hit a hold note
    public KeyCode key;

    private void Awake()
    {
		active = false;
        holding = false;
	}

	private void Start()
    {
        holdLine = null;
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
            else // Hitting a key associated with a KeyboardTimingNote when it's not active counts as a miss
            {
                gradeSprite.SetSprite("Miss");
                scoreManager.EndStreak();
            }
        }
        else if (holdLine != null && holding)
        {
            if (Input.GetKeyUp(key))
            {
                Destroy(holdLine);
                holding = false;
                gradeSprite.SetSprite("Miss");
                scoreManager.EndStreak();
            }
            else
            {
                // Var for how far a hold line is into a KeyboardTimingNote's collider 
                float inCollider = transform.position.y + GetComponent<CircleCollider2D>().radius - holdLine.GetComponent<HoldLine>().endpoint;

                if (inCollider >= 0)
                {
                    holdLine.GetComponent<HoldLine>().length -= inCollider;

                    if (holdLine.GetComponent<HoldLine>().length <= 0.0f)
                    {
                        scoreManager.AddScore(0.0f);
                        Destroy(holdLine);
                    }

                    holdLine.transform.localScale = new Vector3(transform.localScale.x, holdLine.GetComponent<HoldLine>().length, transform.localScale.z);
                    holdLine.transform.position = new Vector3(holdLine.transform.position.x, holdLine.transform.position.y + (inCollider / 2), holdLine.transform.position.z);
                }
            }
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
        active = false;
	}
}
