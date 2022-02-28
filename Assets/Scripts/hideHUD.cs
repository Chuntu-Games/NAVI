using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideHUD : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject shotgun;
    private bool flashlightEquippedOriginal;
    private bool flashlightUseOriginal;
    private bool shotgunEquippedOriginal;
    private bool shotgunUseOriginal;

    // Start is called before the first frame update
    void Start()
    {
        flashlightEquippedOriginal = EquippedObjects.flashlightEquipped;
        flashlightUseOriginal = EquippedObjects.flashlightUse;
        shotgunEquippedOriginal = EquippedObjects.weaponEquipped;
        shotgunUseOriginal = EquippedObjects.weaponUse;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shotgunEquippedOriginal && EquippedObjects.weaponEquipped)
            shotgunEquippedOriginal = EquippedObjects.weaponEquipped;
        if (EquippedObjects.weaponEquipped && (shotgunUseOriginal != EquippedObjects.weaponUse))
            shotgunUseOriginal = EquippedObjects.weaponUse;
        if (EquippedObjects.flashlightEquipped && (flashlightUseOriginal != EquippedObjects.flashlightUse))
            flashlightUseOriginal = EquippedObjects.flashlightUse;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (EquippedObjects.flashlightUse || EquippedObjects.weaponUse)
            {
                Debug.Log("bruh");
                flashlight.SetActive(false);
                shotgun.SetActive(false);
                EquippedObjects.flashlightEquipped = false;
                EquippedObjects.flashlightUse = false;
                EquippedObjects.weaponEquipped = false;
                EquippedObjects.weaponUse = false;
            }
            else if (!EquippedObjects.flashlightEquipped && !EquippedObjects.weaponEquipped)
            {
                Debug.Log("capasao");
                EquippedObjects.flashlightEquipped = flashlightEquippedOriginal;
                EquippedObjects.flashlightUse = flashlightUseOriginal;
                EquippedObjects.weaponEquipped = shotgunEquippedOriginal;
                EquippedObjects.weaponUse = shotgunUseOriginal;

                if (EquippedObjects.flashlightUse)
                    flashlight.SetActive(true);
                else if (EquippedObjects.weaponUse)
                    shotgun.SetActive(true);
            }
        }
    }
}
