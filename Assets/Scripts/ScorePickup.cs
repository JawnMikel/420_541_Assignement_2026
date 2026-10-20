using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    [SerializeField] private int points = 50;
    [SerializeField] private AudioClip pickupSound;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is missing!");
            return;
        }

        GameManager.Instance.AddScore(points);

        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(
                pickupSound,
                transform.position
            );
        }

        Destroy(gameObject);
        }
    }

}
