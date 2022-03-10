using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ResolutionScaling : MonoBehaviour
{
    public static float currentScale = 1.0f;
    public static float value = 1.0f;

    // Simple example of a policy that scales the resolution every secondsToNextChange seconds.
    // Since this call uses DynamicResScalePolicyType.ReturnsMinMaxLerpFactor, HDRP uses currentScale in the following context:
    // finalScreenPercentage = Mathf.Lerp(minScreenPercentage, maxScreenPercentage, currentScale);
    public float SetDynamicResolutionScale()
    {
        currentScale = 0.5f + value * 0.5f;
        return currentScale;
    }

    void Start()
    {
        // Binds the dynamic resolution policy defined above.
        DynamicResolutionHandler.SetDynamicResScaler(SetDynamicResolutionScale, DynamicResScalePolicyType.ReturnsMinMaxLerpFactor);
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        Debug.Log(currentScale);
    }

    // Update is called once per frame
    public void SetDSR(float percentage)
    {
        value = percentage;
        // Binds the dynamic resolution policy defined above.
        DynamicResolutionHandler.SetDynamicResScaler(SetDynamicResolutionScale, DynamicResScalePolicyType.ReturnsMinMaxLerpFactor);
        Debug.Log(currentScale);
    }
}