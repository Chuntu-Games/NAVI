using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneToGo;
    void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        ScenesState.lastScene = currentScene.buildIndex;

        SceneManager.LoadScene(sceneToGo);
        completedScenes.currentScene = sceneToGo;
    }
}
