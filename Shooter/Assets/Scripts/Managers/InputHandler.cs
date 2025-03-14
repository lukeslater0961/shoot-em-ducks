using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    [SerializeField] InputAction spaceAction;
    [SerializeField] InputAction escapeAction;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        spaceAction = InputSystem.actions.FindAction("Start");
        escapeAction = InputSystem.actions.FindAction("GoBack");
    }

    /// <summary>
    /// Checks for parameters and will apply the correct 
    ///     function in the given input context
    /// </summary>
    public void HandleInput()
    {
        if (escapeAction.WasPressedThisFrame())
            escape();
        else if (spaceAction.WasPressedThisFrame())
            space();
    }

    private void escape()
    {
        if (GameMenuManager.instance.inMenu)
            SceneLoader.Instance.LoadMainMenu(true);
        else if (GameManager.instance.inGame)
            GameMenuManager.instance.createGameMenu();
    }

    private void space()
    {
        if (GameMenuManager.instance.inMenu)
            GameMenuManager.instance.startGame();
    }
}   
