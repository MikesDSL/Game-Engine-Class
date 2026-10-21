using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    void Update()
    {
        Quaternion rot = transform.rotation;
        rot.y += speed * Time.deltaTime;
        transform.rotation = rot;
        if (transform.rotation.y >= 0.99 || transform.rotation.y <= -0.99)
        {
            speed *= -1;
        }
    }
}
