using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        print("easrd");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
