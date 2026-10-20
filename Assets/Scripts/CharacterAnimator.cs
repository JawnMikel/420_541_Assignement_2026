using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movement;
    private Rigidbody rb;

    [SerializeField] private AudioClip flipSound;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f) return;
        animator.SetFloat("CharacterSpeed", rb.linearVelocity.magnitude);

        bool grounded = movement.IsGrounded;
        animator.SetBool("IsGrounded", grounded);

        if (grounded)
        {
            animator.ResetTrigger("doDoubleJump");
        }
        else
        {
            if (Input.GetButtonDown("Jump")
                && movement.TryDoubleJump())
            {
                animator.SetTrigger("doDoubleJump");

                if (audioSource != null && flipSound != null)
                {
                    audioSource.PlayOneShot(flipSound);
                }
            }
        }
    }
}
