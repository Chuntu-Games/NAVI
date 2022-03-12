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
    public GameObject panel;
    private bool CR_running = false;
    private bool ending = false;

    void Start()
    {
        timeStamp = Time.time;
    }

    IEnumerator panelAppears()
    {
        CR_running = true;
        panel.SetActive(true);
        yield return new WaitForSeconds(3);
        panel.SetActive(false);
        CR_running = false;
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
            ending = true;
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
        vomit();
    }

    void Update()
    {
        if (ending && timeStamp < Time.time)
        {
            player.GetComponent<CharacterController>().enabled = true;
            camera.GetComponent<LookWithMouse>().enabled = true;
            particleSystem.SetActive(false);
            system1.Stop();
            system2.Stop();
            system3.Stop();

            this.gameObject.GetComponent<Circle>().marker.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}