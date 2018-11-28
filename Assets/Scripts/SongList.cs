
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongList : MonoBehaviour {

    //Create a List of new Dropdown options
    public static List<string> SongNames { get; set; }

    public static List<float> SongBPMs { get; set; }

    //This is the Dropdown
    Dropdown Dropdown;

    void Start()
    {
        SongBPMs = new List<float> {
                108F,
                91F, 
                109F
        };

        SongNames = new List<string> {
                "Twinkle Twinkle Little Star",
                "Back In Black",
                "Walk This Way"
        };

        //Fetch the Dropdown GameObject the script is attached to
        Dropdown = GameObject.FindGameObjectWithTag("Song Dropdown").GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        Dropdown.ClearOptions();
        //Add the options created in the List above
        Dropdown.AddOptions(SongNames);
    }
}