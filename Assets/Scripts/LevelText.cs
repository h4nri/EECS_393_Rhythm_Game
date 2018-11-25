using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour {

	private void Start()
    {
		GetComponent<Text>().text = SceneManager.GetActiveScene().name;
	}
}
