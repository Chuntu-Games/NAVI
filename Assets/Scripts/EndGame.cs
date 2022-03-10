using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject canvas;
    public GameObject image1;
    public GameObject player;
    public GameObject black;
    public GameObject camera;

    IEnumerator TheSequence()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        camera.GetComponent<LookWithMouse>().enabled = false;
        canvas.GetComponent<PauseMenu>().enabled = false;
        black.SetActive(true);

        canvas.GetComponent<FadeToBlack>().fade = true;
        yield return new WaitForSeconds(5);
        image1.SetActive(true);
        yield return new WaitForSeconds(10);
        Debug.Log("Quitting game....");
        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TheSequence());
    }
}
