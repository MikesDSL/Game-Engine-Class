using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText = null;

    public int totalPoints = 0;

    private static GameManager instance = null;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
        Debug.Log("Score: " + totalPoints);
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + totalPoints.ToString();
    }

}
