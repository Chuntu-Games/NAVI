using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesState : MonoBehaviour
{

    public static List<string> inventorylist = new List<string>();

    public static List<Vector3> positions = new List<Vector3>();

    public static bool[] invisibleObjects = new bool[5]; //[linterna, keyfamily, escopeta, mano, hacha, audio]

}
