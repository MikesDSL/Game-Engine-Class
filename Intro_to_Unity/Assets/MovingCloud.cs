using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = speed * Time.deltaTime;
        if (transform.position.x >= 10.5f || transform.position.x <= -10.5f)
        {
            moveDirection.x *= -1;
            transform.position += moveDirection;
        }
        transform.position += moveDirection;
    }
}
