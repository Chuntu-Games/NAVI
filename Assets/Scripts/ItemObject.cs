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
    public GameObject player;


    void Start()
    {
        string pickId = referenceItem.id;

        switch (pickId)
        {
            case "InvLinterna":
                if (ScenesState.invisibleObjects[0])
                {
                    Destroy(gameObject);
                }
                break;
            case "InvKeyFamily":
                if (ScenesState.invisibleObjects[1])
                {
                    Destroy(gameObject);
                }
                break;
            case "InvWC":
                if (ScenesState.invisibleObjects[2])
                {
                    Destroy(gameObject);
                }
                break;
            case "InvHand":
                if (ScenesState.invisibleObjects[3])
                {
                    Destroy(gameObject);
                }
                break;
            case "InvAxe":
                if (ScenesState.invisibleObjects[4])
                {
                    Destroy(gameObject);
                }
                break;
            default:
                //Debug.Log("Ha ido mal");
                break;
        } //[linterna, keyfamily, escopeta, mano, hacha, audio]
    }

    public void OnHandlePickupItem()
    {
        InventorySystem.Instance.Add(referenceItem);
        Destroy(gameObject);
        InventorySystem.Instance.DrawInventory();
        //InventorySystem.Instance.InventoryIds.Add(referenceItem.id);

        string pickId = referenceItem.id;

        ScenesState.inventorylist.Add(pickId);
        switch (pickId)
        {
            case "InvKeyFamily":
                ScenesState.invisibleObjects[1] = true;
                break;
            case "InvHand":
                ScenesState.invisibleObjects[3] = true;
                break;
            case "InvAxe":
                ScenesState.invisibleObjects[4] = true;
                break;
            default:
                //Debug.Log("Ha ido mal");
                break;
        } //[linterna, keyfamily, escopeta, mano, hacha, audio]

    }

    private void OnMouseDown()
    {
        if(ComputeDistance() < 20.0){
            if (pickUp && !weapon)
            {
                ScenesState.invisibleObjects[0] = true; //[linterna, keyfamily, escopeta, mano, hacha, audio]

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
                ScenesState.invisibleObjects[2] = true; //[linterna, keyfamily, escopeta, mano, hacha, audio]


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

    private float ComputeDistance(){
        var dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }
}