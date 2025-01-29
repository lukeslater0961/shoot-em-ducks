using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public void LoadMainMenu(bool on)
    {
        if (gameManager.score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", gameManager.score);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
