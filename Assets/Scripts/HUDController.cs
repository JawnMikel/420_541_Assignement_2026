using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Health")]
    [SerializeField] private TMP_Text healthText;

    private void Update()
    {
        UpdateScore();
        UpdateHealth();
    }

    private void UpdateScore()
    {
        if (GameManager.Instance == null) return;

        scoreText.text =
            "Score: " + GameManager.Instance.score;
    }

    private void UpdateHealth()
    {
        if (GameManager.Instance == null) return;

        healthText.text =
            "Health: " +
            GameManager.Instance.health +
            "/" +
            GameManager.Instance.maxHealth;
    }
}
