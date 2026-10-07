using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit != null)
        {
            Destroy(hit.gameObject);
        }
    }
}
