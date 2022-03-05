using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class jotunnShot : MonoBehaviour
{
    public Volume volume;
    private float coolDownPeriodInSeconds;
    private float timeStamp;
    Fog fog;

    // Start is called before the first frame update
    void Start()
    {
        coolDownPeriodInSeconds = 3.0f;
        timeStamp = Time.time + coolDownPeriodInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExplosionShot()
    {
        Fog tempVignette;
        if (volume.profile.TryGet<Fog>(out tempVignette))
        {
            fog = tempVignette;
        }

        fog.meanFreePath.value = 0.0f;
        timeStamp = Time.time + coolDownPeriodInSeconds;
    }

    void OnMouseOver()
    {
        if (EquippedObjects.weaponUse && Input.GetMouseButtonDown(1) && (timeStamp <= Time.time))
        {
            ExplosionShot();
            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
    }
}
