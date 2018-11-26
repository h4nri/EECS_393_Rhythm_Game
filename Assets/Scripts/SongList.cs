
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongList : MonoBehaviour {

    //Create a List of new Dropdown options
    public static List<string> SongNames { get; set; }

    public static List<int> SongBPMs { get; set; }

    //This is the Dropdown
    Dropdown Dropdown;

    void Start()
    {
        SongBPMs = new List<int> {
                108,
                98,
                140,
                149
        };

        SongNames = new List<string> {
                "Twinkle Twinkle Little Star",
                "Moonlight Sonata",
                "Silent Night",
                "Carol of the Bells"
        };

        //Fetch the Dropdown GameObject the script is attached to
        Dropdown = GameObject.FindGameObjectWithTag("Song Dropdown").GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        Dropdown.ClearOptions();
        //Add the options created in the List above
        Dropdown.AddOptions(SongNames);
    }
}