using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHitSound : MonoBehaviour
{
    AudioSource audioSource; 
    public AudioClip clip;
    

    void Start(){
       audioSource = GetComponent<AudioSource>();
   }

   void OnTriggerEnter(Collider other){
       if(other.tag == "Player"){
           Debug.Log("Voys a sonar");
           audioSource.PlayOneShot(clip, 1f);
       }
   }
}
