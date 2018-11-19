using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GradeSprite : MonoBehaviour {

    private Sprite perfectSprite;
    private Sprite greatSprite;
    private Sprite goodSprite;
    private Sprite badSprite;
    private Sprite missSprite;
    private string path;

    private void Awake()
    {
        path = "Sprites/Score/";
        perfectSprite = Resources.Load<Sprite>(path + "Perfect");
        greatSprite = Resources.Load<Sprite>(path + "Great");
        goodSprite = Resources.Load<Sprite>(path + "Good");
        badSprite = Resources.Load<Sprite>(path + "Bad");
        missSprite = Resources.Load<Sprite>(path + "Miss");
    }

    // Sets the sprite of this GameObject based on grade
    public void SetSprite(string grade)
    {
        switch (grade)
        {
            case "Perfect":
                GetComponent<Image>().sprite = perfectSprite;
                break;
            case "Great":
                GetComponent<Image>().sprite = greatSprite;
                break;
            case "Good":
                GetComponent<Image>().sprite = goodSprite;
                break;
            case "Bad":
                GetComponent<Image>().sprite = badSprite;
                break;
            case "Miss":
                GetComponent<Image>().sprite = missSprite;
                break;
        }
	}
}
