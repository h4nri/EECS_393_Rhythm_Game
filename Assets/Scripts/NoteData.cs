
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class NoteData {

    public bool holdLine;
    public bool link;

    // 0 = up
    // 1 = right
    // 2 = down
    // 3 = left
    // -1 not a directional
    public int direction;

    // Storing the position
    public float pos_x;
    public float pos_y;
    public float pos_z;

    // Storing the rotation
    public float rot_x;
    public float rot_y;
    public float rot_z;

    // Storing the Scale
    public float sca_x;
    public float sca_y;
    public float sca_z;

    public NoteData(bool holdLine, bool link, int direction, float px, float py, float pz, float rx, float ry, float rz, float sx, float sy, float sz)
    {
        this.holdLine = holdLine;
        this.link = link;
        this.direction = direction;
        pos_x = px;
        pos_y = py;
        pos_z = pz;
        rot_x = rx;
        rot_y = ry;
        rot_z = rz;
        sca_x = sx;
        sca_y = sy;
        sca_z = sz;

    }


}
