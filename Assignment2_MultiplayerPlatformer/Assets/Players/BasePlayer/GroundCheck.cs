using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int collisionCounter = 0;

    private float lastGrounded = 0;

    private float coyoteTime = 0.125f;

    void CoyoteCheck()
    {
        if (collisionCounter == 0)
        {
            lastGrounded = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCounter++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCounter--;
        CoyoteCheck();
    }

    public bool IsGrounded()
    {
        return collisionCounter == 0 ? false : true;
    }
    public bool CanCoyote()
    {
        return Time.time <= lastGrounded + coyoteTime;
    }
}
