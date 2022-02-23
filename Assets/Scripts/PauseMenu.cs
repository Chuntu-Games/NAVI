using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused=false; //Esta variable no la uso aqui, solo la pongo para que otros scripts puedan comprovar si el jeugo esta pausado
    public GameObject pauseMenuUI;
    public GameObject GameplayUI;
    public int MainMenuScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameplayUI.SetActive(true);
        Time.timeScale =1f ;
        GameIsPaused= false;
         Cursor.lockState = CursorLockMode.Locked;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameplayUI.SetActive(false);
        Time.timeScale =0f ;
        GameIsPaused= true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadMenu()
    {
        Time.timeScale =1f ;
        SceneManager.LoadScene(MainMenuScene);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game....");
        Application.Quit();

    }
}
