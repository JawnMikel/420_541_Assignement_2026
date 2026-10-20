
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelExitTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Level2";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Level Complete!");


        if (GameManager.Instance != null && nextSceneName != "EndScreen")
        {
        GameManager.Instance.SaveLevelStartScore();
        }


        SceneManager.LoadScene(nextSceneName);
    }
}
