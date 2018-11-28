using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	private AudioSource audioSource;
	private AudioClip audioClip;
    private ScoreManager scoreManager;
	private float clipLength;

    private NoteData[] Notes { get; set; }
    private int SongIndex { get; set; }

    // Current Song and Level name
    private string SongName { get; set; }
    private string LevelName { get; set; }

    private void Awake()
    {
        if (CustomLevelData.LevelData.CustomLevelIsActive)
        {
            SongName = CustomLevelData.LevelData.SongName;
            print("Song Name " + SongName);
            LevelName = CustomLevelData.LevelData.LevelName;
            print("Level Name : " + LevelName);
            foreach (string n in CustomLevelData.LevelData.CustomLevels)
            {
                print(CustomLevelData.LevelData.CustomLevels.IndexOf(n));
                print(n);
            }
            SongIndex = CustomLevelData.LevelData.CustomLevels.IndexOf(LevelName);
            print("Song Index");
            print(SongIndex);
            Notes = CustomLevelData.LevelData.Notes[SongIndex];

            // Instantiate each note that was saved 
            foreach (NoteData note in Notes)
            {
                Vector3 Position = note.GetPosition();
                Vector3 Scaling = note.GetScale();
                Quaternion Rotation = note.GetRotation();

                float XPosition = Position.x;
                string Type = "Prefabs/Basic Notes/" + DetermineNoteType(XPosition);
                Instantiate(Resources.Load(Type), Position, Rotation);


            }

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>(SongName);

            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.speed = CustomLevelData.LevelData.FallSpeeds[SongIndex];




        }
        else
        {
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.speed = 2;
        }
    }

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
		clipLength = audioClip.length;
        audioSource.Play();
		//print("Clip Length: " + clipLength);
	}

	private void Update()
    {
		// print("Time: " + Time.timeSinceLevelLoad);

		if (Time.timeSinceLevelLoad - clipLength > 0.0f)
        {
			StartCoroutine("EndLevel");
		}

        //Check if the game is paused. If so, pause audio 
        if (SettingsManager.isPaused)
        {
            audioSource.Pause();
        }

        //Check if the game is unpaused. If so, unpause audio 
        else if (!(SettingsManager.isPaused))
        {
            audioSource.UnPause();
        }
    }

	IEnumerator EndLevel()
    {
		yield return new WaitForSeconds(1.5f);
        scoreManager.UpdateLeaderboards();
		SceneManager.LoadScene("Game Over");
	}

    private string DetermineNoteType(float XPosition)
    {

        if (XPosition <= -3.9F) // -4.4 Indigo  -4.4 + .5 = -3.9
        {
            return "Indigo Note";
        }
        else if (XPosition > -3.9F & XPosition <= -2.8F) // -3.3 Blue -3.3 + .5 = -2.8 
        {
            return "Blue Note";
        }
        else if (XPosition > -2.8F & XPosition <= -1.7F) // -2.2 Cyan -2.2 + .5 = -1.7
        {
            return "Cyan Note";
        }
        else if (XPosition > -1.7 & XPosition <= -.6F) // -1.1 Green -1.1 +.5 = -.6
        {
            return "Green Note";
        }
        else if (XPosition > -.6F & XPosition <= .5F) // 0 Lime                .5
        {
            return "Lime Note";
        }
        else if (XPosition > .5F & XPosition <= 1.6F) // 1.1 Yellow          1.6
        {
            return "Yellow Note";
        }
        else if (XPosition > 1.6F & XPosition <= 2.7F) // 2.2 Tangerine       2.7
        {
            return "Tangerine Note";
        }
        else if (XPosition > 2.7F & XPosition <= 3.8F) // 3.3 Orange      3.8
        {
            return "Orange Note";
        }
        else                             // 4.4 Red-Orange
        {
            return "Red-Orange Note";
        }

        //if (XPosition.Equals(-3.3F)) // Blue Note 
        //{
        //    return "Blue Note";
        //}
        //else if (XPosition.Equals(-2.2F)) // Cyan Note
        //{
        //    return "Cyan Note";
        //}
        //else if (XPosition.Equals(-1.1F)) // Green Note
        //{
        //    return "Green Note";
        //}
        //else if (XPosition.Equals(-4.4F)) // Indigo Note
        //{
        //    return "Indigo Note";
        //}
        //else if (XPosition.Equals(0F)) // Lime Note
        //{
        //    return "Lime Note";
        //}
        //else if (XPosition.Equals(3.3F)) // Orange Note
        //{
        //    return "Orange Note";
        //}
        //else if (XPosition.Equals(4.4F)) // Red-Orange Note
        //{
        //    return "Red-Orange Note";
        //}
        //else if (XPosition.Equals(2.2F)) // Tangerine Note
        //{
        //    return "Tangerine Note";
        //}
        //else  // Yellow Note
        //{
        //    return "Yellow Note";
        //}
    }
}
