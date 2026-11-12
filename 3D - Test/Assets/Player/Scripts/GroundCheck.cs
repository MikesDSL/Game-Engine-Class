using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int collisionCounter = 0;
    public bool IsGrounded { get { return collisionCounter > 0; } }

    private float coyoteTime = 0.35f;

    private float lastGrounded = 0.0f;

    void CoyoteCheck()
    {
        if (collisionCounter == 0)
        {
            lastGrounded = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            collisionCounter++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            collisionCounter--;
        }
        CoyoteCheck();
    }
    public bool CanCoyote()
    {
        return Time.time <= lastGrounded + coyoteTime;
    }
}