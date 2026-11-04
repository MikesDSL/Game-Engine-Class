using UnityEngine;
using UnityEngine.InputSystem;

public class PumkieController : PlayerController
{
    protected override void Awake()
    {
        playerInput = new();

        moveAction = playerInput.Player2.Move;
        jumpAction = playerInput.Player2.Jump;
        interactAction = playerInput.Player2.Interact;

        base.Awake();
    }

    protected override void OnInteract(InputAction.CallbackContext ctx)
    {

    }
}
