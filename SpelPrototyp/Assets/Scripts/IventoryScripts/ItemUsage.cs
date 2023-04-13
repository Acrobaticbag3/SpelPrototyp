using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsage : MonoBehaviour
{

    public static PlayerManager player;
    //public staic InventoryManager inv;

    private void Start() {
        player = GetComponent<PlayerManager>();
       // inv = InvetoryManager.GetComponen<>();
    }
    static public void UseHealthPotion()
    {
        Debug.Log("pot");
        player.HealPlayer(30);
       // inv.Remove(item);
        
    }
    static public void UseManaPotion()
    {
        Debug.Log("po1");
    }
}
