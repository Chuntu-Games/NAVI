using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarValue : MonoBehaviour
{
    Scrollbar bar;

    public IEnumerator Start()
    {
        Debug.Log("Now its called");
        yield return null; // Waiting just one frame is probably good enough, yield return null does that
        bar = GetComponentInChildren<Scrollbar>();
        bar.value = ResolutionScaling.value;
        Debug.Log("Now its setted");
    }
}
