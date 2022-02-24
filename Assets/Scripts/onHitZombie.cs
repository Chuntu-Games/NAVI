using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHitZombie : MonoBehaviour{
    AudioSource audioSource; 
    public AudioClip clip;

    void Start(){
       audioSource = GetComponent<AudioSource>();
   }

   void OnTriggerEnter(Collider other){
       if(other.tag == "zombie"){
           audioSource.PlayOneShot(clip, 0.5f);
       }
   }

}