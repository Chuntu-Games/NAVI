 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator _animator;
    public List<ItemRequirement> requirements;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void openDoor()
    {
        if (MeetsRequirements())
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            _animator.SetBool("open", true);
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
        openDoor();
    }
}