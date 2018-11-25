using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private GradeSprite gradeSprite;
    public int Multiplier { get; set; }
    public int Score { get; set; }
    public int Streak { get; set; }

    private void Awake()
    {
        Multiplier = 1;
        Score = 0;
        Streak = 0;
    }

    private void Start()
    {
        gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
    }

    private void Update()
    {
        GetComponent<Text>().text = Score + "\n" + Streak + "\n" + Multiplier + "x";
    }

    /** 
     * Adds to current score
     * Amount of score added is based on percentage of overlap between colliders of notes and timing notes
     * 
     * @param distance The distance between centers of colliders
     */
    public void AddScore(float distance)
    {
        float areaOfOverlap = (2.0f * Mathf.Pow(0.5f, 2.0f) * Mathf.Acos(distance / (2.0f * 0.5f))) - ((distance / 2.0f) * (Mathf.Sqrt(4.0f * Mathf.Pow(0.5f, 2.0f)) - Mathf.Pow(distance, 2.0f)));
        float overlapPercentage = areaOfOverlap / (Mathf.PI * Mathf.Pow(0.5f, 2.0f));

        //print ("Overlap Percentage: " + overlapPercentage);

        if ((overlapPercentage <= 1.0f) && (overlapPercentage > 0.8f))
        {
            gradeSprite.SetSprite("Perfect");
            Score = Score + (1000 * Multiplier);
            Streak++;
        } else if ((overlapPercentage <= 0.8f) && (overlapPercentage > 0.6f))
        {
            gradeSprite.SetSprite("Great");
            Score = Score + (850 * Multiplier);
            Streak++;
        } else if ((overlapPercentage <= 0.6f) && (overlapPercentage > 0.4f))
        {
            gradeSprite.SetSprite("Good");
            Score = Score + (500 * Multiplier);
            EndStreak();
        } else if ((overlapPercentage <= 0.4f) && (overlapPercentage > 0.0f))
        {
            gradeSprite.SetSprite("Bad");
            Score = Score + (100 * Multiplier);
            EndStreak();
        }

        if ((Streak >= 10) && (Streak < 20))
        {
            Multiplier = 2;
        } else if (Streak >= 20)
        {
            Multiplier = 3;
        }
    }

    public void EndStreak()
    {
        Streak = 0;
        Multiplier = 1;
    }  

    // Called when a level is finished to potentially update the leaderboards
    public void UpdateLeaderboards()
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if (Score > PlayerPrefs.GetInt(activeScene + "3"))
        {
            if (Score > PlayerPrefs.GetInt(activeScene + "2"))
            {
                if (Score > PlayerPrefs.GetInt(activeScene + "1"))
                {
                    PlayerPrefs.SetInt(activeScene + "3", PlayerPrefs.GetInt(activeScene + "2"));
                    PlayerPrefs.SetInt(activeScene + "2", PlayerPrefs.GetInt(activeScene + "1"));
                    PlayerPrefs.SetInt(activeScene + "1", Score);
                } else
                {
                    PlayerPrefs.SetInt(activeScene + "3", PlayerPrefs.GetInt(activeScene + "2"));
                    PlayerPrefs.SetInt(activeScene + "2", Score);
                }
            } else
            {
                PlayerPrefs.SetInt(activeScene + "3", Score);
            }
        }

        print(activeScene + " #1: " + PlayerPrefs.GetInt(activeScene + "1"));
        print(activeScene + " #2: " + PlayerPrefs.GetInt(activeScene + "2"));
        print(activeScene + " #3: " + PlayerPrefs.GetInt(activeScene + "3"));
    }
}
