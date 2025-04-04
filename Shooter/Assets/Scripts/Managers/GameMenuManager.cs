using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class GameMenuManager : MonoBehaviour
{
	public				static		GameMenuManager instance;

	[SerializeField]	GameObject	HUD;
	[SerializeField]	GameObject	GameMenuHUD;

	[SerializeField]	Button		infinityButton;
	[SerializeField]	Button		normalButton;

	[SerializeField]	TMP_Text	highscoreText;
    [SerializeField]	TMP_Text	livesText;

    [SerializeField]	Camera		menuCamera;
	[SerializeField]	Camera		gameCamera;

    public				bool		inMenu = true;
	private				int			highScore;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	private void Start()
	{
        if (instance)
			createGameMenu();
	}

    private void LateUpdate()
    {
		InputHandler.instance.HandleInput();
    }

    public void createGameMenu()
	{
        inMenu = true;
		HUDHandler.instance.ToggleActive(HUD, false);
		HUDHandler.instance.ToggleActive(GameMenuHUD, true);
        GameManager.instance.inGame = false;

        menuCamera.gameObject.SetActive(true);
        gameCamera.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        highScore = PlayerPrefs.GetInt("HighScore");
		Debug.Log($"got a highscore of {highScore}");
		highscoreText.text = $"Highscore\n    {highScore}";
	}

	public void startGame()
	{
		inMenu = false;
		menuCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
		GameMenuHUD.SetActive(false);
        HUD.SetActive(true);
        GameManager.instance.GameSetup();
    }

	public void setDifficulty(bool On)
	{
        GameManager.instance.runtimeGameSettings.gameDifficulty = GameMode.difficulty.normal;
    }

    public void setGameMode(bool On)
    {
		if (!infinityButton.gameObject.activeSelf)
		{
			infinityButton.gameObject.SetActive(true);
			normalButton.gameObject.SetActive(false);
			GameManager.instance.runtimeGameSettings.gameMode = GameMode.gameModes.infinite;
		}
		else
		{
			infinityButton.gameObject.SetActive(false);
			normalButton.gameObject.SetActive(true);
			GameManager.instance.runtimeGameSettings.gameMode = GameMode.gameModes.normal;
		}
		Debug.Log($"game mode is set to {GameManager.instance.runtimeGameSettings.gameMode}");
    }

	public void setLives(bool On)
	{
		GameManager.instance.runtimeGameSettings.lives = !GameManager.instance.runtimeGameSettings.lives;
		if (GameManager.instance.runtimeGameSettings.lives)
			livesText.text = "On";
		else livesText.text = "Off";
    }
}
