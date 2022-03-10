using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int PlayScene;

    public void PlayGame()
    {
    
        LoadScene.NivelCarga(PlayScene);
    }

     public void QuitGame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();

    }
}
