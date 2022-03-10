using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{


    private void Start(){
        int loadinglevel=LoadScene.siguienteNivel;
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