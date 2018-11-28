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

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
