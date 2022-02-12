using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemRequirement
{
    public InventoryItemData itemData;
    public int amount;

    public bool HasRequirement()
    {
        InventoryItem item = InventorySystem.Instance.Get(itemData);
        
        if (item == null || item.stackSize < amount) {return false;}
        return true;
    }
}

public class DoorObject : MonoBehaviour
{

    public List<ItemRequirement> requirements;

    public void OpenDoor()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            Destroy(gameObject);
            InventorySystem.Instance.DrawInventory();
        }
    }

    private bool MeetsRequirements()
    {
        foreach (ItemRequirement requirement in requirements)
        {
            if(!requirement.HasRequirement()) {return false;}
        }

        return true;
    }

    private void RemoveRequirements()
    {
        foreach (ItemRequirement requirement in requirements)
        {
            for (int i=0; i<requirement.amount; i++)
            {
                InventorySystem.Instance.Remove(requirement.itemData);
            }
        }
    }


    private void OnMouseDown()
    {
        OpenDoor();
    }
}
