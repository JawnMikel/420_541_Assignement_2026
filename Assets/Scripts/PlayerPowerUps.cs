using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    [Header("Speed Boost")]
    [SerializeField] private float boostMultiplier = 2f;

    public float SpeedTimeLeft { get; private set; }

    [Header("Jump Boost")]
    public float JumpTimeLeft { get; private set; }

    [Header("Score Boost")]
    public float ScoreTimeLeft { get; private set; }

    private CharacterMovement movement;

    private void Start()
    {
        movement = GetComponent<CharacterMovement>();
    }

    public void ActivateJumpBoost(float duration)
    {
        JumpTimeLeft = duration;
        movement.CanDoubleJump = true;
    }

    // Orange Speed Boost - 5 seconds
    public void ActivateSpeedBoost(float duration)
    {
        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = boostMultiplier;
    }

    // Purple Score Boost - 10 seconds
    public void ActivateScoreBoost(float duration)
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is missing!");
            return;
        }

        ScoreTimeLeft = duration;
        GameManager.Instance.scoreMultiplier = 2;
    }

    private void Update()
    {
        if (JumpTimeLeft > 0f)
        {
            JumpTimeLeft -= Time.deltaTime;

            if (JumpTimeLeft <= 0f)
            {
                JumpTimeLeft = 0f;
                movement.CanDoubleJump = false;
            }
        }

        if (SpeedTimeLeft > 0f)
        {
            SpeedTimeLeft -= Time.deltaTime;

            if (SpeedTimeLeft <= 0f)
            {
                SpeedTimeLeft = 0f;
                movement.SpeedMultiplier = 1f;
            }
        }

        if (ScoreTimeLeft > 0f)
        {
            ScoreTimeLeft -= Time.deltaTime;

            if (ScoreTimeLeft <= 0f)
            {
                ScoreTimeLeft = 0f;

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.scoreMultiplier = 1;
                }
            }
        }
    }

    private void OnDestroy()
    {

        if (GameManager.Instance != null)
        {
            GameManager.Instance.scoreMultiplier = 1;
        }
    }
}
