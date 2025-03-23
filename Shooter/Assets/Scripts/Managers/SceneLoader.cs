using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField]    GameManager gameManager;
    public static       SceneLoader Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadMainMenu(bool on)
    {
        if (gameManager.score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", gameManager.score);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
