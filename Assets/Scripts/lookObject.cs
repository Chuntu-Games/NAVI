using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class lookObject : MonoBehaviour
{

    public List<ItemRequirement> requirements;
    public GameObject cameraOff;
    public GameObject cameraOn;
    public GameObject ui;
    public GameObject player;

    public void EndScene()
    {
        cameraOn.SetActive(true);
        cameraOff.SetActive(false);
        ui.SetActive(false);
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
        Debug.Log(ComputeDistance());
        if (ComputeDistance() < 7.0)
            EndScene();
    }

    private float ComputeDistance()
    {
        var dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }
}
