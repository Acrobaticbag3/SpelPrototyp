using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsage : MonoBehaviour
{

    public static PlayerManager player;
    public static InventoryManager inv;
    public static ItemController item;
  


    //public staic InventoryManager inv;

    private void Start() {
        player = GetComponent<PlayerManager>();
       // inv = InvetoryManager.GetComponen<>();
    }

    static public void UseHealthPotion()
    {   
        player.HealPlayer(30);
        item.RemoveItem();
    }
    static public void UseManaPotion()
    {
        Debug.Log("po1");
        player.ManaPot(30);
    }
}
