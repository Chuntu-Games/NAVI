using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject marker;
    public GameObject player;

    void OnMouseOver()
    {
        if (ComputeDistance() < 7.0)
            marker.SetActive(true);
        else
            marker.SetActive(false);
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

    private float ComputeDistance()
    {
        var dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }
}
