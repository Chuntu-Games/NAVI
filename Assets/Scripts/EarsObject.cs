using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EarsObject : MonoBehaviour
{

    public List<ItemRequirement> requirements;
    public GameObject ears;
    public GameObject audio;
    public GameObject light;

    public void ShowEars()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            ears.SetActive(true);
        }
    }

    public void EndScene()
    {
        ears.SetActive(false);
        audio.SetActive(true);
        light.SetActive(false);
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
        if (!ears.activeSelf)
            ShowEars();
        else
            EndScene();
    }
}
