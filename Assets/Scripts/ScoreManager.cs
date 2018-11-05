using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    GradeSprite gradeSprite;
    float areaOfOverlap;
    float overlapPercentage;
    public int Multiplier { get; set; }
    public int Score { get; set; }
    public int Streak { get; set; }

    void Awake()
    {
        areaOfOverlap = 0.0f;
        overlapPercentage = 0.0f;
        Multiplier = 1;
        Score = 0;
        Streak = 0;
    }

    void Start()
    {
        gradeSprite = GameObject.Find("Grade Sprite").GetComponent<GradeSprite>();
    }

    void Update()
    {
        GetComponent<Text>().text = Score + "\n" + Streak + "\n" + Multiplier + "x";
    }

    public void AddScore(float distance)
    {
        areaOfOverlap = (2.0f * Mathf.Pow(0.5f, 2.0f) * Mathf.Acos(distance / (2.0f * 0.5f))) - ((distance / 2.0f) * (Mathf.Sqrt(4.0f * Mathf.Pow(0.5f, 2.0f)) - Mathf.Pow(distance, 2.0f)));
        overlapPercentage = areaOfOverlap / (Mathf.PI * Mathf.Pow(0.5f, 2.0f));

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
}
