using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneToGo;
    public GameObject load;

    void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene(sceneToGo);
        load.SetActive(true);
        LoadScene.NivelCarga(sceneToGo);
        completedScenes.currentScene = sceneToGo;
    }
}
