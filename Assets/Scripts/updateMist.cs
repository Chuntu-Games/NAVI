using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class updateMist : MonoBehaviour
{
    public Volume volume;
    Fog fog;
    public GameObject flashlight;

    // Update is called once per frame
    void Update()
    {
        if (!flashlight.GetComponent<FlashLightMech>().isOn)
        {
            Fog tempVignette;
            if (volume.profile.TryGet<Fog>(out tempVignette))
            {
                fog = tempVignette;
            }

            if (fog.meanFreePath.value < 25.0f)
                fog.meanFreePath.value += 0.05f;
        }
    }
}
