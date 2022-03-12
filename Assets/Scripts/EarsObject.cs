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
    public GameObject player;
    public GameObject panel;
    private bool CR_running = false;

    IEnumerator panelAppears()
    {
        CR_running = true;
        panel.SetActive(true);
        yield return new WaitForSeconds(3);
        panel.SetActive(false);
        CR_running = false;
    }

    public void ShowEars()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            ears.SetActive(true);
        }
        else if (!CR_running)
        {
            StartCoroutine(panelAppears());
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
        completedScenes.sceneChildhood = true;
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
        if (!ears.activeSelf && ComputeDistance() < 7.0)
            ShowEars();
        else if (ears.activeSelf && ComputeDistance() < 7.0)
            EndScene();
    }

    private float ComputeDistance()
    {
        var dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }
}
