using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesState : MonoBehaviour
{

    public static List<string> inventorylist = new List<string>();

    public static List<Vector3> positions = new List<Vector3>();

    public static bool[] invisibleObjects = new bool[5]; //[linterna, keyfamily, escopeta, mano, hacha, audio]

    public static bool doorFamily = false;

    public static Vector3[] positionArray = new [] { new Vector3(350.5f, 1.2f, 261.3f), new Vector3(264f, 1.2f, 345.4f), new Vector3(265.3f, 1.2f, 162.6f) };

    public static int lastScene = 0;

}