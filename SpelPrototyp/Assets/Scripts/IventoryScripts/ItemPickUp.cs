using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Caspian
public class ItemPickUp : MonoBehaviour
{   
    public ItemScriptableObejct item;


    public void PickUp()
    {
        Debug.Log("PIck upj ");
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
}
