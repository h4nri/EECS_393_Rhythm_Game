using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

public class ScoreManagerTest {
    /* Does not work at the moment!
    [UnityTest]
    public IEnumerator UpdateCorrectlySetsText() {
        var gradeSprite = new GameObject("Grade Sprite");
        gradeSprite.AddComponent<GradeSprite>();

        var scoreManager = new GameObject();
        scoreManager.AddComponent<ScoreManager>();
        scoreManager.AddComponent<Text>();

        yield return null;
        Debug.Log(scoreManager.GetComponent<Text>().text);

        Assert.True("0\n0\n1x".Equals(scoreManager.GetComponent<Text>().text));

        scoreManager.GetComponent<ScoreManager>().Multiplier = 1;
        scoreManager.GetComponent<ScoreManager>().Score = 1000;
        scoreManager.GetComponent<ScoreManager>().Streak = 1;

        yield return null;

        Assert.That("1000\n1\n1x".Equals(scoreManager.GetComponent<Text>().text));
    }
    */
}
