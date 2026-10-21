using Unity.Mathematics;
using UnityEngine;

public class RotatingCloud : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;
    // Update is called once per frame
    void Update()
    {
     Quaternion rot = transform.rotation;
        rot.y += rotationSpeed * Time.deltaTime;
        transform.rotation = rot;
    }
}
