using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SettingsScript : MonoBehaviour
{
    public RenderPipelineAsset[] qualityLevels;
    public Dropdown resolutionDropdown;
    public TMP_Dropdown quality_drop;
    
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        quality_drop.value = QualitySettings.GetQualityLevel();
        Screen.fullScreen = true;
        QualitySettings.vSyncCount = 1;
    }

    // Update is called once per frame
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        QualitySettings.renderPipeline = qualityLevels[qualityIndex];
    }

    // Update is called once per frame
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Update is called once per frame
    public void SetVsync(bool vsync)
    {
        if (vsync)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
}
