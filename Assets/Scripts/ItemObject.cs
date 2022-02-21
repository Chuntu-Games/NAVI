using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public bool pickUp;
    public bool weapon;
    public GameObject pickObject;

    public void OnHandlePickupItem()
    {
        InventorySystem.Instance.Add(referenceItem);
        Destroy(gameObject);
        InventorySystem.Instance.DrawInventory();
    }

    private void OnMouseDown()
    {
        if (pickUp && !weapon)
        {
            pickObject.SetActive(true);
            Destroy(gameObject);
            EquippedObjects.flashlightEquipped = true;
            EquippedObjects.flashlightUse = true;
            EquippedObjects.weaponUse = false;

        }
        else if (pickUp && weapon)
        {
            pickObject.SetActive(true);
            Destroy(gameObject);
            EquippedObjects.weaponEquipped = true;
            EquippedObjects.weaponUse = true;
            EquippedObjects.flashlightUse = false;
        }
        else
            OnHandlePickupItem();
    }
}
