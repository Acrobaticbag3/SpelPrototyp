//Caspian


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
 
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private GameObject Inv;
    private bool invActive = false;
    public List<ItemScriptableObejct> Items = new List<ItemScriptableObejct>();

    public Transform ItemContent;
    public GameObject IventoryItem;

    private void Awake()
    {
        Instance = this;
        Inv.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (invActive == true)
            {
                CloseInv();
                invActive = false;
            }
            else
            {
                OpenInv();
                invActive = true;
            }
        }

    }

    private void OpenInv()
    {
        ListItems();
        Inv.SetActive(true);
    }
    private void CloseInv()
    {
        Inv.SetActive(false);
    }
    public void Add(ItemScriptableObejct item)
    {
        Items.Add(item);
    }

    public void Remove(ItemScriptableObejct item)
    {   
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(IventoryItem, ItemContent);
            obj.GetComponent<InvItemController>().item = item;

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemSprite").GetComponent<Image>();


            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
           
        }


    } 
} 
