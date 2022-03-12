using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadScene 
{
    public static int siguienteNivel;

    public static void NivelCarga(int nivel){
        siguienteNivel=nivel;
        SceneManager.LoadScene(7);
    }
}
