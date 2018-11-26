using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBase : MonoBehaviour {

    private int BPM = LevelEditor.BPM;
    private string SongName = LevelEditor.SongChoice;
    private int Difficulty = LevelEditor.Difficulty;
    private float DistanceBetweenNotes;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        int FallSpeed = CalculateFallSpeed(Difficulty);
        print("Fallspeed");
        print(FallSpeed);


        double BPS = (double)BPM / (double)60;
        DistanceBetweenNotes = (float) (1 / (BPS / FallSpeed));

        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = Resources.Load<AudioClip>(SongName);
        audioSource.clip = Resources.Load<AudioClip>(SongName);

        double length = audioSource.clip.length;
        int count = 0;
        for (float i = 0; i < length; i = i + DistanceBetweenNotes)
        {
            count++;
            GameObject note = Instantiate(Resources.Load("Prefabs/Basic Notes/Base Note")) as GameObject;
            note.transform.Translate(0 , i, 0);
        }

        Vector3 x = Input.mousePosition;
        Vector2 scroll = Input.mouseScrollDelta;
        print(count);
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
        }
        else if (diff == 1)
        {
            FallSpeed = 3;
        }
        else
        {
            FallSpeed = 2;
        }

        return FallSpeed;
    }
}
