using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float turnSpeed = 10.0f;
    [SerializeField]
    private float jumpSpeed = 10.0f;

    [SerializeField]
    private GroundCheck groundCheck = null;
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private Camera camera = null;

    private Rigidbody rigidBody = null;
    private PlayerInput playerInput = null;
    private InputAction moveInput = null;
    private InputAction jumpInput = null;

    private Vector3 checkpointPosition = Vector3.zero;

    private Vector3 moveVelocity = Vector3.zero;

    private float stunDuration = 0.0f;
    private bool isFalling = false;
    private bool isJumping = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        moveInput = playerInput.Player.Move;
        jumpInput = playerInput.Player.Jump;
        jumpInput.performed += OnJump;

        checkpointPosition = transform.position;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        moveInput.Enable();
        jumpInput.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        moveInput.Disable();
        jumpInput.Disable();
        jumpInput.performed -= OnJump;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (transform.position.y < -10.0f)
        {
            RespawnPlayer();
            return;
        }
        if (stunDuration > 0.0f)
        {
            stunDuration -= Time.deltaTime;
            return;
        }
        Vector2 move = moveInput.ReadValue<Vector2>();
        Vector3 fwd = camera.transform.forward;
        Vector3 right = camera.transform.right;
        fwd.y = 0.0f;
        right.y = 0.0f;
        moveVelocity = ((fwd * move.y) + (right * move.x)) * moveSpeed;

        if (moveVelocity.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(moveVelocity),
                Time.deltaTime * turnSpeed);
        }
        moveVelocity.y = rigidBody.linearVelocity.y;

        if (groundCheck.IsGrounded && rigidBody.linearVelocity.y <= 0.6)
        {
            isFalling = false;
            isJumping = false;
        }
        else if (!groundCheck.IsGrounded && rigidBody.linearVelocity.y < -0.1)
        {
            isFalling = true;
            isJumping = false;
        }
        animator.SetFloat("Speed", move.magnitude);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    private void FixedUpdate()
    {
        if (stunDuration <= 0.0f)
            rigidBody.linearVelocity = moveVelocity;
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (!groundCheck.IsGrounded)
        {
            if (!groundCheck.CanCoyote())
            {
                return;
            }
        }
        if (rigidBody.linearVelocity.y <= 3.5f)
        {
            rigidBody.linearVelocity += new Vector3(0.0f, jumpSpeed, 0.0f);
            isJumping = true;
            isFalling = false;
        }
    }
    public void RespawnPlayer()
    {
        transform.position = checkpointPosition;
    }
    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
    }
    public void StunPlayer(float duration)
    {
        stunDuration = duration;
    }
}