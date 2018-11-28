using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLevelPrefabManager : MonoBehaviour {

    private NoteData[] Notes { get; set; }
    private int SongIndex { get; set;}

    // Current Song and Level name
    private string SongName { get; set; }
    private string LevelName { get; set; }

    // Use this for initialization
    void Awake () {
        SongName = CustomLevelData.LevelData.SongName;
        LevelName = CustomLevelData.LevelData.LevelName;
        SongIndex = CustomLevelData.LevelData.CustomLevels.IndexOf(LevelName);
        Notes = CustomLevelData.LevelData.Notes[SongIndex];

        // Instantiate each note that was saved 
        foreach(NoteData note in Notes) 
        {
            Vector3 Position = note.GetPosition();
            Vector3 Scaling = note.GetScale();
            Quaternion Rotation = note.GetRotation();

            float XPosition = Position.x;
            string Type = DetermineNoteType(XPosition);
            Instantiate(Resources.Load(Type), Position, Rotation);


        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>(SongName);
        if(audioSource.clip != null) {
            print("clip loaded");
        }
    }
	
	private string DetermineNoteType(float XPosition)
    {
        if (XPosition.Equals(-3.3F)) // Blue Note 
        {
            return "Blue Note";
        }
        else if (XPosition.Equals(-2.2F)) // Cyan Note
        {
            return "Cyan Note";
        }
        else if (XPosition.Equals(-1.1F)) // Green Note
        {
            return "Green Note";
        }
        else if (XPosition.Equals(-4.4F)) // Indigo Note
        {
            return "Indigo Note";
        }
        else if (XPosition.Equals(0F)) // Lime Note
        {
            return "Lime Note";
        }
        else if (XPosition.Equals(3.3F)) // Orange Note
        {
            return "Orange Note";
        }
        else if (XPosition.Equals(4.4F)) // Red-Orange Note
        {
            return "Red-Orange Note";
        }
        else if (XPosition.Equals(2.2F)) // Tangerine Note
        {
            return "Tangerine Note";
        }
        else  // Yellow Note
        {
            return "Yellow Note";
        }
    }
}
