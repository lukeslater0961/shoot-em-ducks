using UnityEngine;
using TMPro;

public class HUDHandler : MonoBehaviour
{
	public static HUDHandler instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public void ToggleActive(GameObject hud, bool isVisible)
	{
		hud.SetActive(isVisible);
	}

	/// <summary>
	/// Sets all the correct values for the HUD
	/// </summary>
	public void HudSetup(TMP_Text healthText, TMP_Text roundText, TMP_Text scoreText, bool lives)
	{
		if (GameManager.instance.runtimeGameSettings.lives)
		{
			healthText.gameObject.SetActive(true);
			healthText.text = "/3";
			healthText.text = $"{GameManager.instance.health}" + healthText.text;
        }
        else healthText.gameObject.SetActive(false);

		if (GameManager.instance.runtimeGameSettings.gameMode == GameMode.gameModes.infinite)
			roundText.gameObject.SetActive(true);
		else roundText.gameObject.SetActive(false);

        scoreText.text = $"score = {GameManager.instance.score}";
    }
}
