using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvItemController : MonoBehaviour
{
    ItemScriptableObejct item;

    public Button RemoveBut;
    public void RemoveItem()
    {
        Debug.Log("remove");
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(ItemScriptableObejct newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.id)
        {
            case 1:
            ItemUsage.UseHealthPotion();
                break;
            case 2:
            ItemUsage.UseManaPotion();
                break;
        }
    }
}
