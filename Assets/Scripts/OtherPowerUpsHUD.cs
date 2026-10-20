using UnityEngine;
using TMPro;

public class OtherPowerUpsHUD : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps powerUps;

    [Header("Speed Boost")]
    [SerializeField] private GameObject speedIndicator;
    [SerializeField] private TMP_Text speedTimeText;

    [Header("Score Boost")]
    [SerializeField] private GameObject scoreIndicator;
    [SerializeField] private TMP_Text scoreTimeText;

    private void Update()
    {
        float speedTimeLeft = powerUps.SpeedTimeLeft;

        speedIndicator.SetActive(speedTimeLeft > 0f);

        speedTimeText.text =
            "Speed Boost: " +
            Mathf.CeilToInt(Mathf.Max(0f, speedTimeLeft)) +
            "s";

        float scoreTimeLeft = powerUps.ScoreTimeLeft;

        scoreIndicator.SetActive(scoreTimeLeft > 0f);

        scoreTimeText.text =
            "Score Boost: " +
            Mathf.CeilToInt(Mathf.Max(0f, scoreTimeLeft)) +
            "s";
    }
}
