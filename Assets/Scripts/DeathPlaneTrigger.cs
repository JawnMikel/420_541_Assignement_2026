using UnityEngine;

public class DeathPlaneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell off the level!");

            GameManager.Instance.DieAndRestart();
        }
    }
}
