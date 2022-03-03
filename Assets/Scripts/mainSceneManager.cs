using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSceneManager : MonoBehaviour
{
    public GameObject portalChildhood;
    public GameObject torchChildhood;
    public GameObject flameChildhood;
    public GameObject portalFamily;
    public GameObject torchFamily;
    public GameObject flameFamily;
    public GameObject portalTanks;
    public GameObject torchTanks;
    public GameObject flameTanks;
    public GameObject finalPortal;

    // Start is called before the first frame update
    void Start()
    {
        if (completedScenes.sceneChildhood)
        {
            portalChildhood.SetActive(false);
            torchChildhood.SetActive(false);
            flameChildhood.SetActive(false);
        }
        if (completedScenes.sceneFamily)
        {
            portalFamily.SetActive(false);
            torchFamily.SetActive(false);
            flameFamily.SetActive(false);
        }
        if (completedScenes.sceneTanks)
        {
            portalTanks.SetActive(false);
            torchTanks.SetActive(false);
            flameTanks.SetActive(false);
        }
        if (completedScenes.sceneChildhood && completedScenes.sceneFamily && completedScenes.sceneTanks)
            finalPortal.SetActive(true);
    }
}
