using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] Toggle fpsToggle;
    [SerializeField] Toggle fullScreen;
    [SerializeField] Toggle vsyncToggle;


    void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {

        if (PlayerPrefs.HasKey("FpsCounter"))
        {
            bool isFpsCounterEnabled = PlayerPrefs.GetInt("FpsCounter") == 1;
            fpsToggle.isOn = isFpsCounterEnabled;
        }
        else
            fpsToggle.isOn = false;

        if (PlayerPrefs.HasKey("FullScreen"))
        {
            bool isFullScreenEnabled = PlayerPrefs.GetInt("FullScreen") == 1;
            fullScreen.isOn = isFullScreenEnabled;
        }
        else
            fullScreen.isOn = false;

        if (PlayerPrefs.HasKey("Vsync"))
        {
            bool isVsyncEnabled = PlayerPrefs.GetInt("Vsync") == 1;
            vsyncToggle.isOn = isVsyncEnabled;
        }
        else
            vsyncToggle.isOn = false;
    }

    public  void    SaveSettings(bool On)
    {

        PlayerPrefs.SetInt("FpsCounter", fpsToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("Vsync", vsyncToggle.isOn ? 1 : 0);
        QualitySettings.vSyncCount = vsyncToggle.isOn ? 1 : 0;
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("FullScreen", fullScreen.isOn ? 1 : 0);
        Screen.fullScreen = fullScreen.isOn;
        PlayerPrefs.Save();
    }
}
