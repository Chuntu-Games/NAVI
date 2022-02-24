using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public bool pickUp;
    public bool weapon;
    public GameObject pickObject;
    public GameObject flashlight;
    public GameObject weaponObj;

    public void OnHandlePickupItem()
    {
        InventorySystem.Instance.Add(referenceItem);
        Destroy(gameObject);
        InventorySystem.Instance.DrawInventory();
        InventorySystem.Instance.InventoryIds.Add(referenceItem.id);
    }

    private void OnMouseDown()
    {
        if (pickUp && !weapon)
        {
            pickObject.SetActive(true);
            Destroy(gameObject);
            EquippedObjects.flashlightEquipped = true;
            EquippedObjects.flashlightUse = true;
            if (EquippedObjects.weaponUse)
            {
                weaponObj.SetActive(false);
                EquippedObjects.weaponUse = false;
            }
        }
        else if (pickUp && weapon)
        {
            pickObject.SetActive(true);
            Destroy(gameObject);
            EquippedObjects.weaponEquipped = true;
            EquippedObjects.weaponUse = true;
            if (EquippedObjects.flashlightUse)
            {
                flashlight.SetActive(false);
                EquippedObjects.flashlightUse = false;
            }
        }
        else
            OnHandlePickupItem();
    }
}
