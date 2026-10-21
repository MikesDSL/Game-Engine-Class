using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    void Update()
    {
        Vector3 moveDirection = transform.position;

        if (moveDirection.x >= 10.5f || moveDirection.x <= -10.5f)
        {
            speed *= -1;
            print("EE");
        }

        moveDirection.x = Mathf.Clamp(moveDirection.x + speed * Time.deltaTime,
          -10.5f, 10.5f);

        transform.position = moveDirection;
    }
}
