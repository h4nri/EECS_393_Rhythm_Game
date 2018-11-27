
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[Serializable]
public class NoteData {

    public bool holdLine { get; set; }
    public bool link { get; set; }

    //public string type { get; set; }

    // 0 = up
    // 1 = right
    // 2 = down
    // 3 = left
    // -1 not a directional
    public int direction { get; set; }

    // Storing the position
    private float pos_x { get; set; }
    private float pos_y { get; set; }
    private float pos_z { get; set; }

    // Storing the rotation
    private float rot_x { get; set; }
    private float rot_y { get; set; }
    private float rot_z { get; set; }
    private float rot_w { get; set; }

    // Storing the Scale
    private float sca_x { get; set; }
    private float sca_y { get; set; }
    private float sca_z { get; set; }

    public NoteData(
                     float px, float py, float pz,
                     float rx, float ry, float rz, float rw,
                     float sx, float sy, float sz)
    {
        //this.holdLine = holdLine;
        //this.link = link;
        //this.direction = direction;
        pos_x = px;
        pos_y = py;
        pos_z = pz;

        rot_x = rx;
        rot_y = ry;
        rot_z = rz;
        rot_w = rw;

        sca_x = sx;
        sca_y = sy;
        sca_z = sz;
        //this.type = type;

    }

    public Vector3 GetPosition (NoteData note) 
    {
        return new Vector3(note.pos_x, note.pos_y, note.pos_z);
    }

    public Quaternion GetRotation(NoteData note)
    {
        return new Quaternion(note.rot_x, note.rot_y, note.rot_z, note.rot_w);
    }

    public Vector3 GetScale (NoteData note) 
    {
        return new Vector3(note.sca_x, note.sca_y, note.sca_z);
    }


}
