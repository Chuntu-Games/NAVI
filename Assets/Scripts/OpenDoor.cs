using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private Animator _animator;
    public List<ItemRequirement> requirements;
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        int scene = currentScene.buildIndex;

        _animator = GetComponent<Animator>();
        if(ScenesState.doorFamily && scene == 3) {_animator.SetBool("open", true);}
    }

    void openDoor()
    {
        if (MeetsRequirements() )
        {
            RemoveRequirements();
            InventorySystem.Instance.DrawInventory();

            _animator.SetBool("open", true);
            ScenesState.doorFamily = true;
            audioSource.PlayOneShot(clip, 0.25f);
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