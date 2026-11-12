using Unity.Mathematics;
using UnityEngine;

public class SpinningBat : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody = null;
    [SerializeField]
    private Vector3 spinSpeed = Vector3.zero;

    void Update()
    {
        rigidBody.angularVelocity = spinSpeed * Mathf.Deg2Rad;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other != null && other.gameObject != null)
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.StunPlayer(0.5f);
            }
        }
    }
}
