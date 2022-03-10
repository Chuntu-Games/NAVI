using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneToGo;
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneToGo);
        completedScenes.currentScene = sceneToGo;
    }
}
