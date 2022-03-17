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

    void explosion()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            particleSystem.SetActive(true);
            system1.Play();
            this.gameObject.GetComponent<Circle>().marker.SetActive(false);
            corpse.SetActive(false);
            photos.SetActive(true);

            familySceneManager.showCorpo = false;
            familySceneManager.showPhotos = true;
        }
        else if (!CR_running)
        {
            StartCoroutine(panelAppears());
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