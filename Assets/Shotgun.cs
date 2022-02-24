using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public ParticleSystem system;
    private float coolDownPeriodInSeconds;
    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        coolDownPeriodInSeconds = 3.0f;
        timeStamp = Time.time + coolDownPeriodInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && (timeStamp <= Time.time))
        {
            system.Play();
        }
    }
}
