using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int levelStartScore = 0;
    private int deathPenaltyThisLevel = 0;
    public static GameManager Instance;
    public float ElapsedTime { get; private set; } = 0f;

    [Header("Score")]
    public int score = 0;
    public int scoreMultiplier = 1;

    [Header("Health")]
    public int maxHealth = 3;
    public int health = 3;


    private void Update()
    {
        string currentScene =
        SceneManager.GetActiveScene().name;

        // Only count time during gameplay
        if (currentScene == "Level1" ||
        currentScene == "Level2" ||
        currentScene == "Level3")
        {
        ElapsedTime += Time.deltaTime;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points * scoreMultiplier;

        Debug.Log("Score: " + score);
    }

    public void SaveLevelStartScore()
    {
        levelStartScore = score;
        deathPenaltyThisLevel = 0;
    }

    
    public void ResetScore()
    {
        score = 0;
        scoreMultiplier = 1;
        health = maxHealth;

        levelStartScore = 0;
        deathPenaltyThisLevel = 0;

       ElapsedTime = 0f;
    }

   
    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Player has died!");
            DieAndRestart();
        }
    }

    
    public void RestartLevel()
    {   
        
        score = Mathf.Max(0, levelStartScore - deathPenaltyThisLevel);
        health = maxHealth;
        scoreMultiplier = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void DieAndRestart()
    {
        deathPenaltyThisLevel += 100;
        Debug.Log("Player died! -100 points");
        RestartLevel();

    }
}
