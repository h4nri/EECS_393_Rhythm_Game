using UnityEngine;

public class GameManager : MonoBehaviour {

    private GradeSprite gradeSprite;
	private ScoreManager scoreManager;
    public float speed;
    public float visibleDistance;

    private void Start()
    {
		gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
		scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
	}

    // Destroys GameObjects that enter this GameObject's collider and ends the current streak
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.gameObject);
        gradeSprite.SetSprite("Miss");
        scoreManager.EndStreak();
	}
}
