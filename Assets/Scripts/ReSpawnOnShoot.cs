using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ReSpawnOnShoot : MonoBehaviour
{
   public Transform teleportTarget; //Tp position
   public GameObject player; //The player object
   AudioSource audioSource; 
   public AudioClip clip;
   public bool isPlaying = false;
   public Volume volume;
   Vignette vignette;
    private float coolDownPeriodInSeconds;
    private float timeStamp;

    void Start(){
       audioSource = GetComponent<AudioSource>();
        coolDownPeriodInSeconds = 3.0f;
        timeStamp = Time.time + coolDownPeriodInSeconds;
    }

   void Update(){
        if(!isPlaying){
            StartCoroutine(CheckShoot());
        }
   }

   private IEnumerator CheckShoot(){
       isPlaying = true;
       if(Input.GetMouseButtonDown(1) && (timeStamp <= Time.time))
        {
            audioSource.PlayOneShot(clip, 0.25f);

            //yield return new WaitForSeconds(1.5f);
            yield return new WaitForSeconds(0.0f);  
            player.transform.position = teleportTarget.transform.position; //player position = spawn position

            Vignette tempVignette;
            if (volume.profile.TryGet<Vignette>(out tempVignette))
            {
                vignette = tempVignette;
            }

            vignette.intensity.value = 0.0f;
            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
       isPlaying = false;

   }
}
