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

        string path = Application.persistentDataPath + "/ABRAZA LA INEXISTENCIA.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("I went to the Garden of Love,\n");
        writer.WriteLine("And saw what I never had seen:\n");
        writer.WriteLine("A Chapel was built in the midst,\n");
        writer.WriteLine("Where I used to play on the green.\n");
        writer.WriteLine("\n");
        writer.WriteLine("And the gates of this Chapel were shut,\n");
        writer.WriteLine("And Thou shalt not. writ over the door;\n");
        writer.WriteLine("So I turn’d to the Garden of Love,\n");
        writer.WriteLine("That so many sweet flowers bore.\n");
        writer.WriteLine("\n");
        writer.WriteLine("And I saw it was filled with graves,\n");
        writer.WriteLine("And tomb-stones where flowers should be:\n");
        writer.WriteLine("And Priests in black gowns, were walking their rounds,\n");
        writer.WriteLine("And binding with briars, my joys & desires.\n");
        writer.WriteLine("\n");
        writer.WriteLine("https://drive.google.com/file/d/11WEz-O5suxnW3b24hvyCQrKfml7yElZc/view?usp=sharing");
        writer.WriteLine("\n");
        writer.Close();
        StreamReader reader = new StreamReader(path);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();

        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TheSequence());
    }
}
