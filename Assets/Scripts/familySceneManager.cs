using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class familySceneManager : MonoBehaviour
{
    public static bool showCorpo;
    public static bool showPhotos;

    public GameObject corpo;
    public GameObject photos;

    // Start is called before the first frame update
    void Start()
    {
        if (showCorpo)
            corpo.SetActive(true);

        if (showPhotos)
            photos.SetActive(true);
    }
}