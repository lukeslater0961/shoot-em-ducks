using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 15f;
    private float currentRotationY = 0f;
    private float currentRotationX = 0f;
    private Quaternion targetRotation;
    public bool isInSettings = false;


    private CharacterController characterController;
    [SerializeField] Transform cameraTransform;

    private InputAction lookAction;

    private void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        lookAction = InputSystem.actions.FindAction("look");
        currentRotationY = cameraTransform.localEulerAngles.y;
        currentRotationX = cameraTransform.localEulerAngles.x;
    }

    void LateUpdate()
    {
        if (!isInSettings)
            DoRotation();
    }

    private void DoRotation()
    {
        Vector2 lookValue = lookAction.ReadValue<Vector2>();

        if (lookValue.sqrMagnitude > 0)
        {
            float rotationInputY = lookValue.x * rotationSpeed * Time.deltaTime;
            float rotationInputX = lookValue.y * rotationSpeed * Time.deltaTime;

            currentRotationY += rotationInputY;
            currentRotationX -= rotationInputX;
            currentRotationX = Mathf.Clamp(currentRotationX, -45f, 45f);

            transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
            cameraTransform.rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0f);
        }
    }
}