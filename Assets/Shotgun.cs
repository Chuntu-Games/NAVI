using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public ParticleSystem system;
    private float coolDownPeriodInSeconds;
    private float timeStamp;
    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coolDownPeriodInSeconds = 3.0f;
        timeStamp = Time.time + coolDownPeriodInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && (timeStamp <= Time.time))
        {
            audioSource.PlayOneShot(clip, 0.25f);
            system.Play();
            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
    }
}
