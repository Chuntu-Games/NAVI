using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnOnShoot : MonoBehaviour
{
   public Transform teleportTarget; //Tp position
   public GameObject player; //The player object
   AudioSource audioSource; 
   public AudioClip clip;
   public bool isPlaying = false;

   void Start(){
       audioSource = GetComponent<AudioSource>();
   }

   void Update(){
        if(!isPlaying){
            StartCoroutine(CheckShoot());
        }
   }

   private IEnumerator CheckShoot(){
       isPlaying = true;
       if(Input.GetMouseButtonDown(1)){
            audioSource.PlayOneShot(clip, 0.25f);

            //yield return new WaitForSeconds(1.5f);
            yield return new WaitForSeconds(0.0f);  
            player.transform.position = teleportTarget.transform.position; //player position = spawn position
       }
       isPlaying = false;

   }
}
