using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage(damage);

            Debug.Log("Player hit a trap!");
        }
    }
}
