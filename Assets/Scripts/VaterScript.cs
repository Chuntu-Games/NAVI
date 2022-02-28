using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaterScript : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public GameObject corpse;
    public GameObject particleSystem;
    public ParticleSystem system1;
    public ParticleSystem system2;
    public ParticleSystem system3;
    public List<ItemRequirement> requirements;
    private float coolDownPeriodInSeconds;
    private float timeStamp;

    void Start()
    {
        timeStamp = Time.time;
    }

    void vomit()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            player.GetComponent<CharacterController>().enabled = false;
            camera.GetComponent<LookWithMouse>().enabled = false;
            particleSystem.SetActive(true);
            system1.Play();
            system2.Play();
            system3.Play();
            corpse.SetActive(true);

            coolDownPeriodInSeconds = 3.0f;
            timeStamp = Time.time + coolDownPeriodInSeconds;
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
        vomit();
    }

    void Update()
    {
        if (timeStamp < Time.time)
        {
            player.GetComponent<CharacterController>().enabled = true;
            camera.GetComponent<LookWithMouse>().enabled = true;
            particleSystem.SetActive(false);
            system1.Stop();
            system2.Stop();
            system3.Stop();
        }
    }
}