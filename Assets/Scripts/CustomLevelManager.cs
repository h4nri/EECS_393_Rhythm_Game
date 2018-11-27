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
        Dropdown.AddOptions(CustomLevelData.LevelData.CustomLevels);


    }

}
