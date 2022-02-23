using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int PlayScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(PlayScene);

    }

     public void QuitGame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();

    }
}
