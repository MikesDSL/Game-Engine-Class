using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.StartGame();
    }
}
