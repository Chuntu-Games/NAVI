using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    public List<InventoryItem> Inventory;
    public List<string> InventoryIds;
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;

    public Transform ItemContent;
    public GameObject InventoryItem;


    private void Awake()
    {
        Instance = this;
        Inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        InventoryIds.Add("InvPoison");
        InventoryIds.Add("InvKey");
        LoadInventory(InventoryIds);

        DrawInventory();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            Inventory.Add(newItem);
            //InventoryIds.Add(referenceData.id);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                Inventory.Remove(value);
                InventoryIds.Remove(referenceData.id);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }

    public void DrawInventory()
    {
        foreach(Transform t in ItemContent)
        {
            Destroy(t.gameObject);
        }

        foreach(InventoryItem item in InventorySystem.Instance.Inventory)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
        
            itemIcon.sprite = item.data.icon;
        }
    }

    public void LoadInventory(List<string> SavedIds)
    {

        foreach( var x in SavedIds) {
            Debug.Log(x);
        }

        foreach(var id in SavedIds)
        {
            InventoryItemData referenceItem = Resources.Load<InventoryItemData>("ScriptableObjects/" + id);
            Add(referenceItem);
        }
    }
}