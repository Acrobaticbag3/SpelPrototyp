using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string npcName;

    [TextArea(4, 12)]
    public string[] sentences;
}
