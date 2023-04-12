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
            var button = obj.GetComponent<Button>();

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemSprite").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            // button.onClick.AddListener(GetButtonAction(1));
        }
    }
    /*
    UnityAction<I GetButtonAction(int id){
        UnityAction<ItemUsage> action;
        switch(id){
            case 1:
            Debug.Log("pot");
                return new UnityAction<ItemUsage>(ItemUsage.UseHealthPotion);
            
        }

        return DoNothing;
    }

    void DoNothing(){}

    */
} // tryck på item i inv caller button på item 
