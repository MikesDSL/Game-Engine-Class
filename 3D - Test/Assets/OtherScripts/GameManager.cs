using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text bestTimeText = null;
    [SerializeField]
    private TMP_Text gameTimeText = null;
    private float currentGameTime = 0.0f;
    private static GameManager instance = null;
    public static GameManager Instance {  get { return instance; } }
    private bool isFinished = false;
    private bool gameStarted = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void StartGame()
    {
        currentGameTime = 0.0f;
        isFinished = false;
        gameStarted = true;
    }
    public void EndGame()
    {
        isFinished = true;
        GameData data = SaveManager.Instance.GetGameData();
        if (data.timesPlayed == 0 || data.fastestTime > currentGameTime)
        {
            data.fastestTime = currentGameTime;
        }
        bestTimeText.text = data.fastestTime.ToString("F2");
        gameTimeText.text = currentGameTime.ToString("F2");

        data.timesPlayed++;
        data.topFiveTimes.Add(currentGameTime);
        data.topFiveTimes.Sort();
        while (data.topFiveTimes.Count > 5)
        {
            data.topFiveTimes.RemoveAt(data.topFiveTimes.Count - 1);
        }
        SaveManager.Instance.SetGameData(data);
        SaveManager.Instance.Save();
    }
    private void Start()
    {
        SaveManager.Instance.Load();
        GameData data = SaveManager.Instance.GetGameData();
        bestTimeText.text = data.fastestTime.ToString("F2");
        gameTimeText.text = currentGameTime.ToString("F2");
    }
    private void Update()
    {
        if (!isFinished && gameStarted)
        {
            currentGameTime += Time.deltaTime;
            gameTimeText.text = currentGameTime.ToString("F2");
        }
    }
}
