using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class GameMenuManager : MonoBehaviour
{
	public				static		GameMenuManager instance;

	[SerializeField]	TMP_Text	highscoreText;
	[SerializeField]	GameObject	HUD;

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
        HUD.SetActive(false);
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
        HUD.SetActive(true);
        GameManager.instance.GameSetup();
    }
}