using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class endLookObject : MonoBehaviour
{

    public List<ItemRequirement> requirements;
    public GameObject cameraOff;
    public GameObject cameraOn;
    public GameObject fire;
    public GameObject portals;
    public GameObject ui;
    public bool tanksScene = false;

    public void EndScene()
    {
        cameraOn.SetActive(true);
        cameraOff.SetActive(false);
        fire.SetActive(false);
        portals.SetActive(true);
        ui.SetActive(true);
        if (tanksScene)
            completedScenes.sceneTanks = true;
        else
            completedScenes.sceneFamily = true;
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
        EndScene();
    }
}
