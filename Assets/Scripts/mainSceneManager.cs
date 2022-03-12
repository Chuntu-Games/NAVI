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
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

        if (ScenesState.lastScene > 2 && ScenesState.lastScene < 6)
        {
            player.transform.position = ScenesState.positionArray[ScenesState.lastScene - 3];
        }

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

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(ScenesState.lastScene);
            Debug.Log(ScenesState.positionArray[0]);
            Debug.Log(ScenesState.positionArray[1]);
            Debug.Log(ScenesState.positionArray[2]);
        }  
    }
}
