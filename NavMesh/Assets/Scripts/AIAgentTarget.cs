using UnityEngine;
using UnityEngine.InputSystem;

public class AIAgentTarget : MonoBehaviour
{
    private PlayerInputs input = null;
    private InputAction clickAction = null;

    private void Awake()
    {
        input = new PlayerInputs();
        clickAction = input.Player.Attack;
        clickAction.performed += OnMouseClick;
    }
    private void OnEnable()
    {
        input.Enable();
        clickAction.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
        clickAction.Disable();
    }
    private void OnMouseClick(InputAction.CallbackContext ctx)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hitInfo;
        if (Physics.Raycast(cameraRay, out hitInfo, 100.0f))
        {
            if (hitInfo.collider != null )
            {
                transform.position = hitInfo.point;
            }
        }
    }
}
