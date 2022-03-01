using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EarsObject : MonoBehaviour
{

    public List<ItemRequirement> requirements;
    public GameObject ears;
    public GameObject audio1;
    public GameObject audio2;
    public GameObject light;
    public GameObject portal;
    public GameObject velas;

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
        audio1.SetActive(true);
        audio2.SetActive(true);
        light.SetActive(false);
        portal.SetActive(true);
        velas.SetActive(false);
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
