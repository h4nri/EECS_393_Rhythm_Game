using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Build;

public class CustomLevelManager : MonoBehaviour {

    Dropdown Dropdown;

    void Start()
    {

        Dropdown = GameObject.FindGameObjectWithTag("Custom Song Dropdown").GetComponent<Dropdown>();
        Dropdown.ClearOptions();
        if (CustomLevelData.LevelData.CustomLevels != null) 
        {
            Dropdown.AddOptions(CustomLevelData.LevelData.CustomLevels);
        }
        else
        {
            List<string> list = new List<string>();
            list.Add("No Current Custom Levels");
            Dropdown.AddOptions(list);
        }


    }

}
