using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Kevin
[System.Serializable]
public class Dialogue {
    public string npcName;

    [TextArea(4, 12)]
    public string[] sentences;

    [TextArea(2, 6)]
    private string[] btnResponse; // Responses foe the player
}
