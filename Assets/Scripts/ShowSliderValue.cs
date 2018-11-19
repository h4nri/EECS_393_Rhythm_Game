using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSliderValue : MonoBehaviour {

    //Reference to Audio Source component
    private AudioSource audioSource;

    //Music volume value percentage obtained from Volume slider
    private float musicVol = 1f;

	// Use this for initialization
	void Start () {

        //Assigning Audio Source
        audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update () {

        //Set Volume to slider value
        audioSource.volume = musicVol;
    }

    //Set musicVol variable to be slider value from Settings GUI
    public void SetVolume(float vol)
    {
        musicVol = vol;
    }
}
