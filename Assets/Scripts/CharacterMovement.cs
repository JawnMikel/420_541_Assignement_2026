using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;

    [Header("Jump Settings")]
    [SerializeField] private float minJumpForce = 5f;
    [SerializeField] private float maxJumpForce = 10f;
    [SerializeField] private float maxChargeTime = 3f;
    [SerializeField] private float doubleJumpForce = 4f;

    [Header("Ground Check Settings")]
    [SerializeField] private float groundDistance = 1.1f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;
    private Vector3 moveDirection;

    private bool isRunning;
    private bool isGrounded;
    private bool jumpRequested = false;
    private bool doubleJumpRequested = false;
    private bool hasDoubleJumped = false;


    public bool CanDoubleJump { get; set; } = false;

  
    private bool isCharging = false;
    private float chargeTime = 0f;
    private float chargedJumpForce;

    private bool hasJumped = false;
    private bool hasLeftGround = false;

    public bool IsGrounded => isGrounded;

    public float SpeedMultiplier { get; set; } = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {

        if (Time.timeScale == 0f) return;
        // 1. Ground Check - From Lab 5
        isGrounded = Physics.Raycast(
            transform.position + transform.up * groundDistance / 2,
            -transform.up,
            groundDistance,
            groundMask
        );

        if (!isGrounded)
        {
            hasLeftGround = true;

            if (isCharging)
            {
                isCharging = false;
                chargeTime = 0f;
            }
        }
        else if (hasLeftGround)
        {
            hasJumped = false;
            hasDoubleJumped = false;
            hasLeftGround = false;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = (
            transform.right * moveX +
            transform.forward * moveZ
        ).normalized;

        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetButtonDown("Jump")
            && isGrounded && !hasJumped && !jumpRequested)
        {
            isCharging = true;
            chargeTime = 0f;
        }

        if (isCharging)
        {
            chargeTime += Time.deltaTime;

            if (Input.GetButtonUp("Jump")
                || chargeTime >= maxChargeTime)
            {
                float chargePercent =
                    Mathf.Clamp01(chargeTime / maxChargeTime);

                chargedJumpForce = Mathf.Lerp(
                    minJumpForce,
                    maxJumpForce,
                    chargePercent
                );

                jumpRequested = true;
                isCharging = false;
                hasJumped = true;
                chargeTime = 0f;
            }
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();

   
        if (jumpRequested)
        {
            Jump(chargedJumpForce);
            jumpRequested = false;
        }   

    
        if (doubleJumpRequested)
        {
            Jump(doubleJumpForce);
            doubleJumpRequested = false;
        }
    }

    private void MovePlayer()
    {
        float currentSpeed = moveSpeed;

        if (isRunning)
        {
            currentSpeed = moveSpeed * 2f;
        }

        // Lab 7 speed multiplier
        Vector3 targetVelocity =
            moveDirection * currentSpeed * SpeedMultiplier;

        rb.linearVelocity = new Vector3(
            targetVelocity.x,
            rb.linearVelocity.y,
            targetVelocity.z
        );
    }

    private void Jump(float force)
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            0f,
            rb.linearVelocity.z
        );

        rb.AddForce(
            Vector3.up * force,
            ForceMode.VelocityChange
        );
    }

    public bool TryDoubleJump()
    {   
        if (!CanDoubleJump)
        {
        return false;
        }   


        if (isGrounded || hasDoubleJumped || !hasJumped || jumpRequested)
        {
        return false;
        }

        doubleJumpRequested = true;
        hasDoubleJumped = true;

        return true;
    }
}