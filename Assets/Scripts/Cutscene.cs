using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{

    public GameObject Cam0;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        audioSource.Play();
        yield return new WaitForSeconds(19);
        Cam1.SetActive(true);
        Cam0.SetActive(false);
        yield return new WaitForSeconds(25);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(15);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
