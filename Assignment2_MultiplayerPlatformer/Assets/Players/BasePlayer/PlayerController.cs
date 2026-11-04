using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected Animator animator = null;

    [SerializeField]
    protected int player = 1;

    [SerializeField]
    protected float moveSpeed = 5.0f;

    [SerializeField]
    protected float jumpForce = 6.0f;

    [SerializeField]
    protected Rigidbody2D rigidBody = null;

    [SerializeField]
    GroundCheck groundCheck = null;

    protected PlayerInput playerInput = null;
    protected InputAction moveAction = null;
    protected InputAction jumpAction = null;
    protected InputAction interactAction = null;

    protected bool isJumping = false;
    protected bool isFalling = false;

    protected Vector3 lastSafePosition = Vector3.zero;
    protected float desiredSpeed = 0.0f;
    protected float direction = 1.0f;

    protected virtual void Awake()
    {
        jumpAction.performed += OnJump;
        interactAction.performed += OnInteract;

        lastSafePosition = transform.position;
        animator.SetFloat("Direction", 1.0f);
    }

    protected void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }
    protected void OnDisable()
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

    protected void FixedUpdate()
    {
        rigidBody.linearVelocityX = desiredSpeed;
    }

    protected void OnJump(InputAction.CallbackContext ctx)
    {
        if (!groundCheck.IsGrounded())
        {
            if (!groundCheck.CanCoyote()) { return; }
        }
        if (rigidBody.linearVelocityY < 0.1f)
        {
            rigidBody.linearVelocityY = jumpForce;
            isJumping = true;
        }
    }
    protected virtual void OnInteract(InputAction.CallbackContext ctx)
    {
        
    }
    public void RespawnPlayer()
    {
        transform.position = lastSafePosition;
        rigidBody.linearVelocityY = 0;
    }
}
