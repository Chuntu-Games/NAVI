using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        InventorySystem.Instance.Add(referenceItem);
        Destroy(gameObject);
        InventorySystem.Instance.DrawInventory();
        InventorySystem.Instance.InventoryIds.Add(referenceItem.id);
    }

    private void OnMouseDown()
    {
        OnHandlePickupItem();
    }
}
