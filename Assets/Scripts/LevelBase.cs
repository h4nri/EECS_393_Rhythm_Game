using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelBase : MonoBehaviour
{

    private int BPM = LevelEditor.BPM;
    private string SongName = LevelEditor.SongChoice;
    private int Difficulty = LevelEditor.Difficulty;
    private float NotesPerBeat;
    AudioSource audioSource;
    public string LevelName { get; set;}
    int FallSpeed;

    // Use this for initialization
    void Start () {

        // Calculating based off of formula in README
        FallSpeed = CalculateFallSpeed(Difficulty);
        double BPS = (double)BPM / (double)60;
        NotesPerBeat = (float) (1 / (BPS / FallSpeed)); // units = notes/beat

        // Getting correct audiosource and length in seconds
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>(SongName);

        // length of audio in seconds
        double length = audioSource.clip.length; // length in seconds
        double beats = BPS * length; // length in beats

        int NumberNotes = (int)(beats * NotesPerBeat);
        int number = 0; 
        for (float i = NotesPerBeat; i < length * FallSpeed; i = i + NotesPerBeat/FallSpeed)
        {
            number++;
            GameObject note = Instantiate(Resources.Load("Prefabs/Basic Notes/Base Note")) as GameObject;
            note.transform.Translate(0 , i, 0);
        }
        print("COUNT = " + number);
        //Vector3 x = Input.mousePosition;
        //Vector2 scroll = Input.mouseScrollDelta;

        // Naming the new level, making sure no duplicates
        LevelName = "Custom Level: " + SongName + " - " + LevelName;
        string BaseName = LevelName;
        int count = 1;
        while (CustomLevelData.LevelData.CustomLevels.IndexOf(LevelName) != -1)
        {
            LevelName = BaseName + " " + count;
            count++;
        }

    }
	

	void OnUpdate () {

        //GameObject[] AllNotes = GameObject.FindGameObjectsWithTag("BaseNote");
        //foreach (GameObject o in AllNotes)
        //{
        //    Vector3 pos = o.transform.position;
        //    pos.y += Input.GetAxis("Vertical") * 1;
        //    o.transform.Translate(pos);

        //}

    }

    private int CalculateFallSpeed(int diff) 
    {
        int FallSpeed;
        if (diff == 0)
        {
            FallSpeed = 1;
            LevelName = "Easy";
        }
        else if (diff == 1)
        {
            FallSpeed = 2;
            LevelName = "Medium";
        }
        else
        {
            FallSpeed = 4;
            LevelName = "Hard";
        }

        return FallSpeed;
    }

    public void SaveCurrentLevel() 
    {

        // Add all the current notes to a GameObject
        GameObject[] notes;
        notes = GameObject.FindGameObjectsWithTag("BaseNote");

        NoteData[] NoteDatas = new NoteData[notes.Length];
        int count = 0;
        foreach(GameObject note in notes){
            Vector3 position = note.transform.position;
            Quaternion rotation = note.transform.rotation;
            Vector3 scaling = note.transform.localScale;
            NoteData data = new NoteData(position.x, position.y, position.z,
                                         rotation.x, rotation.y, rotation.z, rotation.w,
                                         scaling.x, scaling.y, scaling.z);
            NoteDatas[count] = data;
            count++;
        }

        CustomLevelData.LevelData.CustomLevels.Add(LevelName);
        CustomLevelData.LevelData.SongNames.Add(SongName);
        CustomLevelData.LevelData.Notes.Add(NoteDatas);
        CustomLevelData.LevelData.FallSpeeds.Add(FallSpeed);

        // Save the newly updated data
        CustomLevelData.LevelData.Save();

        // Go back to the Level Select
        SceneManager.LoadScene("Custom Level Select");


    }



}
