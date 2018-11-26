using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : MonoBehaviour {

    public static string SongChoice { get; set;}
    public static int Difficulty { get; set;}
    public static int BPM { get; set;}


    Dropdown SongDropdown;

    private void Update()
    {
        SongDropdown = GameObject.FindGameObjectWithTag("Song Dropdown").GetComponent<Dropdown>();
        SongChoice = SongList.SongNames[SongDropdown.value];
        BPM = SongList.SongBPMs[SongDropdown.value];
        Difficulty = GameObject.FindGameObjectWithTag("Difficulty Dropdown").GetComponent<Dropdown>().value;

    }
}
