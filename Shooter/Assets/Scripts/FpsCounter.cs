using UnityEngine;

public class FpsCounter : MonoBehaviour
{
	[SerializeField]    float           updateInterval = 0.5f;
	[SerializeField]    bool			isCounterActive = false;
	private             float           accum = 0.0f;
	private             float           frames = 0;
	private             float           timeleft;
	private             float           fps;

	GUIStyle textStyle = new GUIStyle();//initialises the style

	void Start()
	{
		CheckForSettings();
		timeleft = updateInterval;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
	}
	public  void    CheckForSettings()
	{
		if (PlayerPrefs.HasKey("FpsCounter"))
			isCounterActive = PlayerPrefs.GetInt("FpsCounter") == 1;
		else
			isCounterActive = false;
	}
	void Update()
	{
		CheckForSettings();
		if (isCounterActive)
		{
			timeleft -= Time.deltaTime;
			accum += Time.timeScale / Time.deltaTime;
			frames++;

			if (timeleft <= 0.0)
			{
				fps = (accum / frames);//gets the average fps
				timeleft = updateInterval;
				accum = 0.0f;   //resets all values
				frames = 0;
			}//gets the amount of frames and gets the average
		}
	}
	void OnGUI()
	{
		if (isCounterActive)
			GUI.Label(new Rect(Screen.width - 80, 5, 100, 25), fps.ToString("F2") + "FPS", textStyle);
	}//only shows the UI when the toggle is ticked in the settings
}
