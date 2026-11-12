using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.SetCheckpoint(transform.position);
            }
        }
    }
}
