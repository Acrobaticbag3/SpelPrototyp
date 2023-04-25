using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quests  {
    private string questId; 
    private string questName;
    private int questXp;

    enum QuestsStates {
        Pending,
        Active,
        Compleated
    }
}
