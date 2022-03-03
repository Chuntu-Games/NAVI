using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class jotunnMist : MonoBehaviour
{
    public Volume volume;
    Fog fog;
    private bool colliding;
    public GameObject flashlight;

    // Start is called before the first frame update
    void Start()
    {
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding && flashlight.GetComponent<FlashLightMech>().isOn)
        {
            Fog tempVignette;
            if (volume.profile.TryGet<Fog>(out tempVignette))
            {
                fog = tempVignette;
            }

            fog.meanFreePath.value -= 0.05f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        colliding = true;
    }


    void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}
