using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator settingAnimator;
    [SerializeField] InputAction escapeAction;
    [SerializeField] Canvas settingsCanvas;
    [SerializeField] PlayerController playerController;
    public bool ison = false;

    private int Score = 0;
    void Start()
    {
        escapeAction = InputSystem.actions.FindAction("GoBack");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (escapeAction.WasPressedThisFrame() && !ison && !playerController.isInSettings)
        {
            playerController.isInSettings = true;
            Cursor.visible = true;
            ison = true;
            settingsCanvas.gameObject.SetActive(true);
            settingAnimator.SetTrigger("trigger");
        }
        else if (escapeAction.WasPressedThisFrame() && ison)
        {
            settingAnimator.SetTrigger("trigger2");
            settingsCanvas.gameObject.SetActive(false);
            Cursor.visible = false;
            ison = false;
            playerController.isInSettings = false;
        }
    }
}
