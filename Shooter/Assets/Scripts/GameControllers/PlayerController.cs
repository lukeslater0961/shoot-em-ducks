using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField]	float				rotationSpeed = 15f;
	private				float				currentRotationY = 0f;
	private				float				currentRotationX = 0f;
	private				float				barrelDefaultAngle = 146f;

	public				bool				isInSettings = false;
	private				bool				firstSet = false;
	private				Quaternion			targetRotation;

	private				CharacterController characterController;
	[SerializeField]	Transform			cameraTransform;
	[SerializeField]	Transform			BarrelTransform;
	private				InputAction			lookAction;

    private void Awake()
    {
        // Use dynamic update to match input events with the frame update
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
    }

    private void Start()
	{
		currentRotationY = transform.eulerAngles.y;
		currentRotationX = cameraTransform.eulerAngles.x;
		Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
		Mouse.current.WarpCursorPosition(screenCenter);
		Cursor.visible = false;
		characterController = GetComponent<CharacterController>();
		lookAction = InputSystem.actions.FindAction("look");
	}

	void Update()
	{
		if (!isInSettings && !GameMenuManager.instance.inMenu)
			DoRotation();
	}

	private void DoRotation()
	{
		Vector2 lookValue = lookAction.ReadValue<Vector2>();

		if(!firstSet)
		{
			lookValue = new Vector2(0, 0);
			firstSet = true;
			return;
		}

		if (lookValue.sqrMagnitude > 0)
		{
			float rotationInputY = lookValue.x * rotationSpeed * Time.deltaTime;
			float rotationInputX = lookValue.y * rotationSpeed * Time.deltaTime;

			currentRotationY += rotationInputY;
			currentRotationX -= rotationInputX;

			currentRotationX = Mathf.Clamp(currentRotationX, -25f, 20f);
			currentRotationY = Mathf.Clamp(currentRotationY, barrelDefaultAngle - 45f, barrelDefaultAngle + 45f);

			transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
			cameraTransform.rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0f);
			BarrelTransform.rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0f);
		}
	}
}
