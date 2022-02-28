using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseExplosion : MonoBehaviour
{
    public GameObject particleSystem;
    public ParticleSystem system1;
    public GameObject corpse;
    public GameObject photos;
    public List<ItemRequirement> requirements;


    void explosion()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            particleSystem.SetActive(true);
            system1.Play();
            corpse.SetActive(false);
            photos.SetActive(true);
        }
    }

    private bool MeetsRequirements()
    {
        foreach (ItemRequirement requirement in requirements)
        {
            if (!requirement.HasRequirement()) { return false; }
        }

        return true;
    }

    private void RemoveRequirements()
    {
        foreach (ItemRequirement requirement in requirements)
        {
            for (int i = 0; i < requirement.amount; i++)
            {
                InventorySystem.Instance.Remove(requirement.itemData);
            }
        }
    }


    private void OnMouseDown()
    {
        explosion();
    }
}