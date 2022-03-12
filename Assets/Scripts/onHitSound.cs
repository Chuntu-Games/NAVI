using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHitSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    private bool listened = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !listened)
        {
            Debug.Log("Voys a sonar");
            audioSource.PlayOneShot(clip, 1f);
            listened = true;
        }
    }
}