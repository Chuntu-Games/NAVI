using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDObjects : MonoBehaviour
{

    public GameObject flashlight;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        if (EquippedObjects.flashlightEquipped && EquippedObjects.flashlightUse)
            flashlight.SetActive(true);
        else if (EquippedObjects.weaponEquipped && EquippedObjects.weaponUse)
            weapon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EKey"))
        {
            if (EquippedObjects.flashlightUse && EquippedObjects.weaponEquipped)
            {
                EquippedObjects.flashlightUse = false;
                EquippedObjects.weaponUse = true;
                flashlight.SetActive(false);
                weapon.SetActive(true);
            }
            else if (EquippedObjects.weaponUse && EquippedObjects.flashlightEquipped)
            {
                EquippedObjects.weaponUse = false;
                EquippedObjects.flashlightUse = true;
                weapon.SetActive(false);
                flashlight.SetActive(true);
            }
        }
    }
}
