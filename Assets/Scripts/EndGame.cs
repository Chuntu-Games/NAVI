using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        Directory.CreateDirectory(Application.streamingAssetsPath + "/ABRAZA LA INEXISTENCIA/");
        string textDocumentName = Application.streamingAssetsPath + "/ABRAZA LA INEXISTENCIA/" + "abraza la inexistencia" + ".txt";

        //Write some text to the test.txt file
        File.WriteAllText(textDocumentName, "I went to the Garden of Love,\n");
        File.AppendAllText(textDocumentName, "And saw what I never had seen:\n");
        File.AppendAllText(textDocumentName, "A Chapel was built in the midst,\n");
        File.AppendAllText(textDocumentName, "Where I used to play on the green.\n");
        File.AppendAllText(textDocumentName, "\n");
        File.AppendAllText(textDocumentName, "And the gates of this Chapel were shut,\n");
        File.AppendAllText(textDocumentName, "And Thou shalt not. writ over the door;\n");
        File.AppendAllText(textDocumentName, "So I turn’d to the Garden of Love,\n");
        File.AppendAllText(textDocumentName, "That so many sweet flowers bore.\n");
        File.AppendAllText(textDocumentName, "\n");
        File.AppendAllText(textDocumentName, "And I saw it was filled with graves,\n");
        File.AppendAllText(textDocumentName, "And tomb-stones where flowers should be:\n");
        File.AppendAllText(textDocumentName, "And Priests in black gowns, were walking their rounds,\n");
        File.AppendAllText(textDocumentName, "And binding with briars, my joys & desires.\n");
        File.AppendAllText(textDocumentName, "\n");
        File.AppendAllText(textDocumentName, "https://drive.google.com/file/d/11WEz-O5suxnW3b24hvyCQrKfml7yElZc/view?usp=sharing");
        File.AppendAllText(textDocumentName, "\n");

        StartCoroutine(TheSequence());
    }
}
