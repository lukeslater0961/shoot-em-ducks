using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator           settingAnimator;
    [SerializeField] InputAction        escapeAction;
    [SerializeField] Canvas             settingsCanvas;
    [SerializeField] PlayerController   playerController;
    [SerializeField] TMP_Text           scoreText;

    public bool                         ison = false;
    public int                          score = 0;
    private int                         highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        //Debug.Log($"got a highscore of {highScore}");
        scoreText.text = $"score = {score}";
        escapeAction = InputSystem.actions.FindAction("GoBack");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (escapeAction.WasPressedThisFrame() && !ison && !playerController.isInSettings)
        {
            settingAnimator.SetTrigger("trigger");
            settingsCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ison = true;
            playerController.isInSettings = true;
        }
        else if (escapeAction.WasPressedThisFrame() && ison)
        {
            settingAnimator.SetTrigger("trigger2");
            settingsCanvas.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ison = false;
            playerController.isInSettings = false;
        }
    }

    public void addPoints(int type)
    {
        score += type * 10;
        scoreText.text = $"score = {score}";
    }
}
