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
    public List<GameObject[]> Notes { get; set; }

    public float levels;
    public float notes;

    void Awake()
    {
        if (LevelData == null) {
            DontDestroyOnLoad(gameObject);
            LevelData = this;
        }
        else if (LevelData != this)
        {
            Destroy(gameObject);
        }


    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerdata.dat");
        PlayerData data = new PlayerData();
        data.levels = 100F;
        data.notes = 200F;
        formatter.Serialize(file, data);

        file.Close();
        

    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerdata.dat")) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerdata.dat", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();

            levels = data.levels;
            notes = data.notes;
        }
    }



}

[Serializable]
class PlayerData 
{
    //public List<string> CustomLevels;
    //public List<float[][]> Notes;

    public float levels;
    public float notes;


}


