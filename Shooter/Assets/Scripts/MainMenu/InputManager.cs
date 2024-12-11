using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField]    Camera      playerCamera;
    [SerializeField]    Animator    cameraAnimator;
    [SerializeField]    OutlineManager outlineManager;
    [SerializeField]    MaineMenuManager mainMenuManager;

    private             InputAction mouseAction;
    private             InputAction mouseClick;
    private             InputAction EscapeClick; 
    private             GameObject  currentSelectedObject;
    public              bool        isInSelect = false;

    void Start()
    {
        mouseAction = InputSystem.actions.FindAction("MousePosition");
        mouseClick = InputSystem.actions.FindAction("Click");
        EscapeClick = InputSystem.actions.FindAction("GoBack");
    }


    private void Update()
    {
        if (isInSelect == true)
            SelectObject();
    }

    void LateUpdate()
    {
        if (isInSelect && EscapeClick.WasPressedThisFrame())
            SceneManager.LoadScene("MainMenu");
    }

    public void SelectObject()
    {
        Vector2 mousePosition = mouseAction.ReadValue<Vector2>();
        Ray ray = playerCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;


            if (hitObject.tag == "Selectable")
            {
                if (hitObject != currentSelectedObject)
                {
                    outlineManager.RemoveOutline(currentSelectedObject);
                    currentSelectedObject = hitObject;
                    outlineManager.ApplyOutline(currentSelectedObject);
                }
            }
            else
            {
                outlineManager.RemoveOutline(currentSelectedObject);
                currentSelectedObject = null;
            }
        }

        if (mouseClick.WasPressedThisFrame() && currentSelectedObject != null)
        {
            if (currentSelectedObject.layer == 7)
                mainMenuManager.StartGame();
            else if (currentSelectedObject.layer == 6)
                Debug.Log("Going into Weapon Selection" + currentSelectedObject.tag);
        }
    }
}