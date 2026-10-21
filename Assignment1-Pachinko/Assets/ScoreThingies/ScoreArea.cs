using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    [SerializeField]
    private int score;
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit != null)
        {
            ScoreManager.Instance.AddPoints(score);
            Destroy(hit.gameObject);
        }
    }
}
