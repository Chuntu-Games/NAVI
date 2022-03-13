using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class JotunnWalk : MonoBehaviour
{

    // Variables privadas
    private Vector3 waypointActual;
    private int wpElegido;

    // @ Variables Publicas
    public float velocidad;

    // @ Arrays
    private ArrayList listaWaypoints = new ArrayList();

    // @ Comportamiento
    private bool walk = true;

    static GameObject[] RandomizeArray(GameObject[] arr)
    {
        for (var i = arr.Length - 1; i > 0; i--)
        {
            var r = Random.Range(0, i);
            var tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }

        return arr;
    }

    void Start()
    {
        // @ Agregamos las posiciones de los waypoints a la lista
        GameObject[] waypoints_init = GameObject.FindGameObjectsWithTag("waypoint");
        GameObject[] waypoints = RandomizeArray(waypoints_init);

        foreach (GameObject waypoint in waypoints)
        {
            listaWaypoints.Add(waypoint.transform.position);
        }

        // @ Definimos el primer waypoint al cual dirigirse
        waypointActual = (Vector3)listaWaypoints[0];
    }


    void Update()
    {
        comprobarDistancia();
        if (walk)
            Walk();
        else
        {
            StartCoroutine(Wait());
        }

    }

    void Walk()
    {
        //GetComponent<Animation>().CrossFade("walk");
        moveNPCTowards(waypointActual);
    }

    IEnumerator Wait()
    {
        //GetComponent<Animation>().CrossFade("idle");
        yield return new WaitForSeconds(1.0f);
        walk = true;
    }


    void comprobarDistancia()
    {
        // Elegimos un waypoint nuevo cuando ya se acerco lo suficiente al actual
        if (Vector3.Distance(transform.position, waypointActual) < 10.0f)
            selectNewWaypoint();
    }

    void selectNewWaypoint()
    {
        if (++wpElegido == listaWaypoints.Count) wpElegido = 0;
        waypointActual = (Vector3)listaWaypoints[wpElegido];

        walk = false;
    }

    void moveNPCTowards(Vector3 waypointActual)
    {

        // Direccion: definimos el vector direccion hacia el cual nos vamos a mover (restamos posicion objetivo - posicion nuestra)
        Vector3 direccion = waypointActual - transform.position;
        // Movimiento:_Son "nuevas posiciones" cada vez mas cercanas al objetivo.
        // normalizar el vector es como obtener en lugar de toda la ruta, en que direccion tiene que dar "cada pequeño paso"
        // al multiplicar por la velocidad, determinamos que tan "largo" es ese paso.
        // usamos time.deltatime para que tenga un movimiento smooth respecto de los frames.

        Vector3 movimiento = direccion.normalized * velocidad * Time.deltaTime;

        transform.LookAt(waypointActual);
        transform.position = transform.position + movimiento;

        Vector3 temp = transform.position;
        temp.y = -2.5f;
        transform.position = temp;
    }



}
