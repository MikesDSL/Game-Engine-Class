using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision != null) && (collision.gameObject.GetComponentInParent<PlayerController>() != null) )
        {
            collision.gameObject.GetComponentInParent<PlayerController>().RespawnPlayer();
        }
    }
}
