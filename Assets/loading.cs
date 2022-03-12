using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{


    private void Start(){
        int loadinglevel=LoadScene.siguienteNivel;
        StartCoroutine(IniciarCarga(loadinglevel));
   
    }

    IEnumerator IniciarCarga(int nivel){
        AsyncOperation operacion=SceneManager.LoadSceneAsync(nivel);
        operacion.allowSceneActivation=false;


        while(!operacion.isDone){

            if(operacion.progress > 0.9f){
                operacion.allowSceneActivation=true;

            }
            yield return null;
        }
        
    }
}
