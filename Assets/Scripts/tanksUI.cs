using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tanksUI : MonoBehaviour
{

    public List<ItemRequirement> requirements;
    public GameObject ui;
    public GameObject text;
    public GameObject player;

    public void ReadMode()
    {
        if (ComputeDistance() < 25.0)
        {
            ui.SetActive(true);
            text.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
    }

    public void PlayMode()
    {
        ui.SetActive(false);
        text.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
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
        if (!ui.activeSelf)
            ReadMode();
        else
            PlayMode();
    }

    private float ComputeDistance()
    {
        var dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }
}
