using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class MaineMenuManager : MonoBehaviour
{

	[SerializeField]	Animator        cameraAnimator;
    [SerializeField]    SettingsManager settingsManager;

    [SerializeField]    Volume          globalVolume;
	[SerializeField]	Canvas          mainMenuCanvas;
	[SerializeField]	Canvas          settingsMenuCanvas;
    [SerializeField]    InputManager    inputManager;

    private ChromaticAberration         chromaticAberration;
    private DepthOfField                depthOfField;
    private VolumeProfile               profile;

    void Start()
    {
        Cursor.visible = true;
        mainMenuCanvas.enabled = true;
        settingsMenuCanvas.enabled = false;
        settingsManager.LoadSettings();  // Load once at start
        VolumeProfile profile = globalVolume.profile;
        EnableEffects();
    }

    public void ExitMainMenu()
	{
        DisableEffects();
		cameraAnimator.SetTrigger("trigger");
		mainMenuCanvas.enabled = false;
        inputManager.isInSelect = true;
    }

    public void EnterSettings()
    {
        mainMenuCanvas.enabled = false;
        settingsMenuCanvas.enabled = true;
    }

    public void ExitSettings()
    {
        mainMenuCanvas.enabled = true;
        settingsMenuCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif //quits the gamemode in the editor (to be removed at the end)
    }

    public void StartGame(){
        SceneManager.LoadSceneAsync("Game");
    }


    //these functions enable and disable the global volume depth of field and chromatic aberation effects
    public void DisableEffects()
    {
        if (globalVolume.profile.TryGet(out chromaticAberration))
            chromaticAberration.active = false;
        if (globalVolume.profile.TryGet(out depthOfField))
            depthOfField.active = false;
    }

    public void EnableEffects()
    { 
        if (globalVolume.profile.TryGet(out chromaticAberration))
            chromaticAberration.active = true;
        if (globalVolume.profile.TryGet(out depthOfField))
            depthOfField.active = true;
    }
}
