using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float respawnDelay = 30f;

    [SerializeField] private GameObject visuals;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPowerUps powerUps =
            other.GetComponent<PlayerPowerUps>();

        if (powerUps == null) return;

        powerUps.ActivateSpeedBoost(duration);

        // Sound
        if (pickupSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(
                pickupSound
            );
        }

        if (pickupEffect != null)
        {
            Instantiate(
                pickupEffect,
                transform.position,
                Quaternion.identity
            );
        }

        visuals.SetActive(false);
        GetComponent<Collider>().enabled = false;

        Invoke(nameof(Reappear), respawnDelay);
    }

    private void Reappear()
    {
        visuals.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
}
