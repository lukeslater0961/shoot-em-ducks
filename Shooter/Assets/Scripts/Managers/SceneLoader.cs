using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    
    public void LoadMainMenu(bool on)
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
