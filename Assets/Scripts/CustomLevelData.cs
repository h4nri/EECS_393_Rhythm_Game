using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class CustomLevelData : MonoBehaviour
{
    public static CustomLevelData LevelData;

    public List<string> CustomLevels { get; set; }
    public List<NoteData[]> Notes {get; set;}
    public List<string> SongNames { get; set; }

    // Current Song and Level name
    Dropdown Dropdown;
    public string SongName { get; set; }
    public string LevelName { get; set; }
    public bool CustomLevelIsActive { get; set; }

    // Pseudo Singleton Object for the player's level data
    void Awake()
    {
        if (LevelData == null) {
            DontDestroyOnLoad(gameObject);
            LevelData = this;
            LevelData.CustomLevels = new List<string>();
            LevelData.Notes = new List<NoteData[]>();
            LevelData.SongNames = new List<string>();
            LevelData.CustomLevelIsActive = false;
        }
        else if (LevelData != this)
        {
            Destroy(gameObject);
        }


    }


    public void UpdateValue()
    {

        Dropdown = GameObject.FindGameObjectWithTag("Custom Song Dropdown").GetComponent<Dropdown>();
        LevelName = CustomLevelData.LevelData.CustomLevels[Dropdown.value];
        print("Curren count = " + CustomLevelData.LevelData.SongNames.Count);
        SongName = CustomLevelData.LevelData.SongNames[Dropdown.value];

    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
        PlayerData data = new PlayerData();
        data.CustomLevels = this.CustomLevels;
        data.Notes = this.Notes;
        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat")) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            this.CustomLevels = data.CustomLevels;
            this.Notes = data.Notes;
            this.SongNames = data.SongNames;
            file.Close();
        }
    }

    public void Clear()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerData.dat");
            LevelData.CustomLevels = new List<string>();
            LevelData.Notes = new List<NoteData[]>();
            LevelData.SongNames = new List<string>();

            Dropdown = GameObject.FindGameObjectWithTag("Custom Song Dropdown").GetComponent<Dropdown>();
            Dropdown.ClearOptions();
            Dropdown.AddOptions(CustomLevelData.LevelData.CustomLevels);

        }
    }


}





