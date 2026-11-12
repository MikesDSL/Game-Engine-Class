using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public delegate void GameEventListener(GameEvent gameEvent);
    public GameEventListener GameEventListeners { get; private set; }

    private static GameEventManager instance = null;
    public static GameEventManager Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void Broadcast(GameEvent gameEvent)
    {
        GameEventListeners?.Invoke(gameEvent);
    }
}
