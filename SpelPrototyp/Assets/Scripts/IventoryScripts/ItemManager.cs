using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemScriptableObejct item;

    public void PickUp()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }
}
