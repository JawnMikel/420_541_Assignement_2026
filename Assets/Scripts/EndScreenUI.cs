using UnityEngine;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TMP_Text finalTimeText;

    private void Start()
    {
        int finalScore = 0;
        float finalTime = 0f;

        if (GameManager.Instance != null)
        {
            finalScore = GameManager.Instance.score;
            finalTime = GameManager.Instance.ElapsedTime;
        }

        finalScoreText.text =
            "Final Score: " + finalScore;

        int totalSeconds = Mathf.FloorToInt(finalTime);

        finalTimeText.text =
            $"Time: {totalSeconds / 60:00}:{totalSeconds % 60:00}";
    }
}
