using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[SerializeField] Canvas             settingsCanvas;
	[SerializeField] TMP_Text           scoreText;

	[SerializeField] Animator           settingAnimator;

	public bool inGame = false;

	public int                          score = 0;

    private void Awake()
    {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
	{

	}

	public void  GameSetup()
	{
		scoreText.text = $"score = {score}";
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		inGame = true;
		TargetSpawner.Instance.gameLaunch();//  starts target spawn
	}

	public void addPoints(int type)
	{
		score += type * 10;
		scoreText.text = $"score = {score}";
	}
}
