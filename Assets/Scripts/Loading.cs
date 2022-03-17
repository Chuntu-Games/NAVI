using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    public GameObject loadMain;
    public GameObject loadTanks;
    public GameObject loadChildhood;
    public GameObject loadFamily;
    public GameObject loadEnding;
    public GameObject loadMenu;


    private void Start(){
        int loadinglevel=LoadScene.siguienteNivel;
        switch (loadinglevel)
        {
            case 0:
                loadMenu.SetActive(true);
                break;
            case 1:
                loadMenu.SetActive(true);
                break;
            case 2:
                loadMain.SetActive(true);
                break;
            case 3:
                loadFamily.SetActive(true);
                break;
            case 4:
                loadTanks.SetActive(true);
                break;
            case 5:
                loadChildhood.SetActive(true);
                break;
            case 6:
                loadEnding.SetActive(true);
                break;
        }
                StartCoroutine(IniciarCarga(loadinglevel));
        
        
    }

    IEnumerator IniciarCarga(int nivel){
        AsyncOperation operacion=SceneManager.LoadSceneAsync(nivel);
       Debug.Log("loadinglevel");

        while(!operacion.isDone){

           
            yield return null;
        }
        
    }
}