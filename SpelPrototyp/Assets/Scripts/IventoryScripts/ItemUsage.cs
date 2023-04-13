using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsage : MonoBehaviour
{

    public static PlayerManager player;
    static public void UseHealthPotion()
    {
        player.HealPlayer(30);
    }
    static public void UseManaPotion()
    {

    }
}
