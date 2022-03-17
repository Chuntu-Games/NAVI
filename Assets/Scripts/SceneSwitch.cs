using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneToGo;
    public GameObject load;
    public bool familyScene;
    public GameObject granja;

    void OnTriggerEnter(Collider other)
    {
        if (familyScene)
        {
            EquippedObjects.flashlightEquipped = granja.GetComponent<hideHUD>().flashlightEquippedOriginal;
            EquippedObjects.flashlightUse = granja.GetComponent<hideHUD>().flashlightUseOriginal;
            EquippedObjects.weaponEquipped = granja.GetComponent<hideHUD>().shotgunEquippedOriginal;
            EquippedObjects.weaponUse = granja.GetComponent<hideHUD>().shotgunUseOriginal;
        }

        //SceneManager.LoadScene(sceneToGo);
        completedScenes.currentScene = sceneToGo;
        Scene currentScene = SceneManager.GetActiveScene();
        ScenesState.lastScene = currentScene.buildIndex;

        //SceneManager.LoadScene(sceneToGo);
        load.SetActive(true);
        LoadScene.NivelCarga(sceneToGo);
    }
}
