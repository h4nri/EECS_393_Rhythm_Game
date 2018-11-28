using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class CustomLevelData : MonoBehaviour
{
    // Pseudo Singleton Object for the player's level data
    public static CustomLevelData LevelData;

    public List<string> CustomLevels { get; set; }
    public List<NoteData[]> Notes {get; set;}

    public List<string> SongNames { get; set; }

    void Awake()
    {
        if (LevelData == null) {
            DontDestroyOnLoad(gameObject);
            LevelData = this;
            LevelData.CustomLevels = new List<string>();
            LevelData.Notes = new List<NoteData[]>();
        }
        else if (LevelData != this)
        {
            Destroy(gameObject);
        }


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

    public void Load() {
        print("filepath");
        print(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/playerData.dat")) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            this.CustomLevels = data.CustomLevels;
            this.Notes = data.Notes;
        }
    }


}





