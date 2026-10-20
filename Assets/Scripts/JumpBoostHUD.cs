using UnityEngine;
using TMPro;

public class JumpBoostHUD : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps powerUps;
    [SerializeField] private GameObject jumpIndicator;
    [SerializeField] private TMP_Text jumpTimeText;

    private void Update()
    {
        float timeLeft = powerUps.JumpTimeLeft;

        // Show only when the boost is active
        jumpIndicator.SetActive(timeLeft > 0f);

        // Show remaining seconds
        jumpTimeText.text =
            "Double Jump: " +
            Mathf.CeilToInt(Mathf.Max(0f, timeLeft)) +
            "s";
    }
}
