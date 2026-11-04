using UnityEngine;
using UnityEngine.InputSystem;

public class GhostieController : PlayerController
{
    protected override void Awake()
    {
        playerInput = new();

        moveAction = playerInput.Player1.Move;
        jumpAction = playerInput.Player1.Jump;
        interactAction = playerInput.Player1.Interact;

        base.Awake();
    }

    protected override void OnInteract(InputAction.CallbackContext ctx)
    {

    }
}
