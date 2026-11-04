using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool grounded = false;
    private void OnTriggerEnter(Collider other)
    {
        grounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
    public bool IsGrounded()
    {
        return grounded;
    }
}
