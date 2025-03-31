using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[SerializeField]	TMP_Text			scoreText;
    [SerializeField]	TMP_Text			healthText;
    [SerializeField]	TMP_Text			roundText;

    public				GameMode			gameSettings;
    public				GameMode			runtimeGameSettings;

    public				bool				inGame = false;
    public				int					score = 0;
	public				int					health = 3;

    private void Awake()
    {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
        runtimeGameSettings = Instantiate(gameSettings);//runtime instance of the scriptable object to reset values
    }

	public void  GameSetup()
	{
		HUDHandler.instance.hudSetup(healthText, roundText, scoreText);
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


	public void ReduceHealth()
	{
		if (runtimeGameSettings.lives)
		{
			health--;
			if (health <= 0)
				GameOver(1);
			healthText.text = "/3";
			healthText.text = $"{health}" + healthText.text;
		}
	}

	/// <summary>
	/// Handles all GameOver types and loads the screen in consequence (to be worked on) 
	/// </summary>
	public void GameOver(int type)
	{
		switch(type)
		{
			case 1:
				Debug.Log("Game over, no more lives");
				GameMenuManager.instance.createGameMenu();
			break;
		}
	}

}
