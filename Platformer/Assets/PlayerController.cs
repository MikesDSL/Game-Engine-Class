using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpForce = 6.0f;

    [SerializeField]
    private Rigidbody2D rigidBody = null;

    [SerializeField]
    GroundCheck groundCheck = null;

    private Controls playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;

    private bool isJumping = false;
    private bool isFalling = false;

    private Vector3 lastSafePosition = Vector3.zero;
    private float desiredSpeed = 0.0f;
    private float direction = 1.0f;

    private void Awake()
    {
        playerInput = new();
        moveAction = playerInput.Player.Move;
        jumpAction = playerInput.Player.Jump;
        jumpAction.performed += OnJump;
        lastSafePosition = transform.position;
        animator.SetFloat("Direction", 1.0f);
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        desiredSpeed = moveAction.ReadValue<Vector2>().x * moveSpeed;
        if (groundCheck.IsGrounded())
        {
            lastSafePosition = transform.position;
            if (rigidBody.linearVelocityY < 0.1f)
            {
                isFalling = false;
            }
        }
        else if (rigidBody.linearVelocityY < 0.0f)
        {
            isFalling = true;
            isJumping = false;
        }
        if (desiredSpeed < 0.0f)
        {
            direction = -1.0f;
        }
        if (desiredSpeed > 0.0f)
        {
            direction = 1.0f;
        }

        float currentSpeed = rigidBody.linearVelocityX;
        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocityX = desiredSpeed;
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (groundCheck.IsGrounded() && rigidBody.linearVelocityY < 0.1f)
        {
            rigidBody.linearVelocityY = jumpForce;
            isJumping = true;
        }
    }
    public void RespawnPlayer()
    {
        transform.position = lastSafePosition;
        rigidBody.linearVelocityY = 0;
    }
}
