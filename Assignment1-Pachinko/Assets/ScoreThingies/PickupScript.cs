using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField]
    private int points = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            ScoreManager.Instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}