using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerData {

    public List<string> CustomLevels { get; set; }
    public List<NoteData[]> Notes { get; set; }
    public List<string> SongNames { get; set; }

}
