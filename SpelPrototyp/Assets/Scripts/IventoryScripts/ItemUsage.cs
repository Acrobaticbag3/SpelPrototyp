using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsage : MonoBehaviour
{

    public static PlayerManager player;
    public static InventoryManager inv;
    public static InvItemController item;
  


   

    private void Start() 
    {
        player = GetComponent<PlayerManager>();
    }

    static public void UseHealthPotion()
    {   
        Debug.Log("Used Hppot");
        player.HealPlayer(30);
    }
    static public void UseManaPotion()
    {
        Debug.Log("USed manapot");
        player.ManaPot(30);
    }
}
