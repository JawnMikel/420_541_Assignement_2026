using UnityEngine;
using TMPro;

public class GameTimerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private void Update()
    {
        if (GameManager.Instance == null) return;

        float elapsedTime =
            GameManager.Instance.ElapsedTime;

        int totalSeconds =
            Mathf.FloorToInt(elapsedTime);

        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timerText.text =
            $"Time: {minutes:00}:{seconds:00}";
    }
}
