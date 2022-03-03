using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{

    public GameObject Cam0;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;
    public GameObject Cam5;
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
        yield return new WaitForSeconds(15);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(9.666666f);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(8.333333f);
        Cam4.SetActive(true);
        Cam3.SetActive(false);
        yield return new WaitForSeconds(9.033333f);
        Cam5.SetActive(true);
        Cam4.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(2);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(2);
        }
    }
}
