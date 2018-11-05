using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

public class GameSpriteTest {

    [Test]
    public void SetSpriteCorrectlySetsSprites() {
        var gradeSprite = new GameObject();
        gradeSprite.AddComponent<GradeSprite>();
        gradeSprite.AddComponent<Image>();

        gradeSprite.GetComponent<GradeSprite>().SetSprite("Perfect");
        Assert.AreSame(Resources.Load("Sprites/Score/Perfect/"), gradeSprite.GetComponent<Image>().sprite);

        gradeSprite.GetComponent<GradeSprite>().SetSprite("Great");
        Assert.AreSame(Resources.Load("Sprites/Score/Great/"), gradeSprite.GetComponent<Image>().sprite);

        gradeSprite.GetComponent<GradeSprite>().SetSprite("Good");
        Assert.AreSame(Resources.Load("Sprites/Score/Good/"), gradeSprite.GetComponent<Image>().sprite);

        gradeSprite.GetComponent<GradeSprite>().SetSprite("Bad");
        Assert.AreSame(Resources.Load("Sprites/Score/Bad/"), gradeSprite.GetComponent<Image>().sprite);

        gradeSprite.GetComponent<GradeSprite>().SetSprite("Miss");
        Assert.AreSame(Resources.Load("Sprites/Score/Miss/"), gradeSprite.GetComponent<Image>().sprite);
    }
}
