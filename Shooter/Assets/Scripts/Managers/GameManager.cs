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
		hudSetup();
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


	/// <summary>
	/// Sets all the correct values for the HUD
	/// </summary>
	public void hudSetup()
	{
		Debug.Log(runtimeGameSettings.lives);
		if (runtimeGameSettings.lives)
		{
			healthText.gameObject.SetActive(true);
			healthText.text = $"{health}" + healthText.text;
        }
        else healthText.gameObject.SetActive(false);

		if (runtimeGameSettings.gameMode == GameMode.gameModes.infinite)
			roundText.gameObject.SetActive(true);
		else roundText.gameObject.SetActive(false);

        scoreText.text = $"score = {score}";
    }
}
