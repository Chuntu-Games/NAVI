using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject marker;
    
     void OnMouseOver()
    {
        marker.SetActive(true);
    }

    void OnMouseExit()
    {
        marker.SetActive(false);
    }
    void OnDestroy()
    {
         if (gameObject.scene.isLoaded) {
             
            marker.SetActive(false);
        }
    }
}
