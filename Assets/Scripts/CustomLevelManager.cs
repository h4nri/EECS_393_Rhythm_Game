using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomLevelManager : MonoBehaviour {

    Dropdown Dropdown;
    public string SongName { get; set; }
    public string LevelName { get; set; }

    void Start()
    {
        Dropdown = GameObject.FindGameObjectWithTag("Custom Song Dropdown").GetComponent<Dropdown>();
        Dropdown.ClearOptions();
        Dropdown.AddOptions(CustomLevelData.LevelData.CustomLevels);
    }

    void Update()
    {
        Dropdown = GameObject.FindGameObjectWithTag("Custom Song Dropdown").GetComponent<Dropdown>();
        LevelName = CustomLevelData.LevelData.CustomLevels[Dropdown.value];
        SongName = CustomLevelData.LevelData.SongNames[Dropdown.value];

    }

    //public void AddPrefabsToPlay() {
    //    Scene scene = SceneManager.GetSceneByName("Custom Level Play");
    //    SceneManager.SetActiveScene(scene);

    //}

}
