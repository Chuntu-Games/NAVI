using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int PlayScene;
    public GameObject settingsMenu;
    public GameObject settingsButton;
    public GameObject quitButton;
    public GameObject playButton;
    public GameObject resumeButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(completedScenes.currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();
    }

    public void Settings()
    {
        settingsButton.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        resumeButton.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void SettingsBack()
    {
        settingsButton.SetActive(true);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        resumeButton.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
