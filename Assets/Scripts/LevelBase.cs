﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelBase : MonoBehaviour
{

    private int BPM = LevelEditor.BPM;
    private string SongName = LevelEditor.SongChoice;
    private int Difficulty = LevelEditor.Difficulty;
    private float DistanceBetweenNotes;
    AudioSource audioSource;
    public string LevelName { get; set;}

    // Use this for initialization
    void Start () {
        int FallSpeed = CalculateFallSpeed(Difficulty);
        double BPS = (double)BPM / (double)60;
        DistanceBetweenNotes = (float) (1 / (BPS / FallSpeed));

        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = Resources.Load<AudioClip>(SongName);
        audioSource.clip = Resources.Load<AudioClip>(SongName);

        double length = audioSource.clip.length;

        for (float i = 0; i < length; i = i + DistanceBetweenNotes)
        {
            GameObject note = Instantiate(Resources.Load("Prefabs/Basic Notes/Base Note")) as GameObject;
            note.transform.Translate(0 , i, 0);
        }

        //Vector3 x = Input.mousePosition;
        //Vector2 scroll = Input.mouseScrollDelta;
        LevelName = "Custom Level: " + SongName + " - " + LevelName;

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
            FallSpeed = 4;
            LevelName = "Easy";
        }
        else if (diff == 1)
        {
            FallSpeed = 3;
            LevelName = "Medium";
        }
        else
        {
            FallSpeed = 2;
            LevelName = "Hard";
        }

        return FallSpeed;
    }

    public void SaveCurrentLevel() 
    {
        CustomLevelData.LevelData.CustomLevels.Add(LevelName);

        // Add all the current notes to a GameObject
        GameObject[] notes;
        notes = GameObject.FindGameObjectsWithTag("Note");
        CustomLevelData.LevelData.Notes.Add(notes);

        // Load the play version of this level 
        CustomLevelData.LevelData.Save();


    }

}
