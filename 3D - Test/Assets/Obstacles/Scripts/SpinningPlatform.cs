using DG.Tweening;
using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;

    private float currentRotation = 0.0f;

    public bool doX = false;

    private void Update()
    {
        currentRotation += rotationSpeed + Time.deltaTime;
        if (!doX )
        transform.rotation = Quaternion.Euler(0.0f, currentRotation, 0.0f);
        else
            transform.rotation = Quaternion.Euler(currentRotation, 0.0f, 0.0f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}
