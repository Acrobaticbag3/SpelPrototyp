//Caspian

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvItemController : MonoBehaviour
{
    public ItemScriptableObejct item;
    public PlayerManager player;


    private void Start() 
    {
        player = GetComponentInChildren<PlayerManager>();
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }


    public void UseItem()
    {   
        switch (item.id)
        {
            case 1:
                Debug.Log("healded");
                ItemUsage.UseHealthPotion();
                break;
            case 2:
                Debug.Log("mana");
                ItemUsage.UseManaPotion();
                break;
        }
    }
}
