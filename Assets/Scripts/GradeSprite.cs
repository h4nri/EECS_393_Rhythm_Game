using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GradeSprite : MonoBehaviour {

	public Sprite perfectSprite;
	public Sprite greatSprite;
	public Sprite goodSprite;
	public Sprite badSprite;
	public Sprite missSprite;

	void Start()
    {

	}

	void Update()
    {
		
	}

	public void SetSprite(string grade)
    {
		if (grade.Equals("Perfect"))
        {
			GetComponent<Image>().sprite = perfectSprite;
		} else if (grade.Equals("Great"))
        {
			GetComponent<Image>().sprite = greatSprite;
		} else if (grade.Equals("Good"))
        {
			GetComponent<Image>().sprite = goodSprite;
		} else if (grade.Equals("Bad"))
        {
			GetComponent<Image>().sprite = badSprite;
		} else if (grade.Equals("Miss"))
        {
			GetComponent<Image>().sprite = missSprite;
		}
	}
}
