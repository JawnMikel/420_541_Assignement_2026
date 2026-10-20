using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetScore();
        }

        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

       public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
